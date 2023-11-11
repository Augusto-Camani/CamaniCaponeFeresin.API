using CamaniCaponeFeresin.API.Entities; //Importamos el namespace de las ENTIDADES.
using Microsoft.EntityFrameworkCore;  //Importamos ENTITY FRAMEWORK para poder heredar de la clase DbContext.

namespace CamaniCaponeFeresin.API.DBContext //Definimos nuestro namespace.
{
    public class AppDBContext : DbContext //Declaramos la clase y aplicamos la herencia de clase.
    {
        //Definimos el constructor para nuestro contexto.
        //Permitimos a nuestro contexto que sea una opción válida.
        //Pasamos nuestra opción de la clase, al constructor de nuestra clase padre (DbContext).
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        //Permitimos que nuestra entidad sea consultada y guardada dentro de la base de datos. Creamos la tabla "Users" (Las tablas siempre llevan nombre en plural).
        public DbSet<User> Users { get; set; }  //Cada DbSet es una tabla nueva en nuestra BASE DE DATOS.
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Purchases { get; set; } //Aquí tenemos tabla de usuarios, ventas, línea de ventas y productos.
        public DbSet<SaleLine> PurchaseLines { get; set; }
        public DbSet<Product> Products { get; set; }


        //Hacemos la sobre escritura en el método OnModelCreating de la clase padre DbContext. 
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Utilizamos la clase ModelBuilder, que permite crear un modelo para nuestro contexto al sobreescribirlo.
        {
            //Hacemos que nuestro modelo, reconozca un elemento (Objeto) del tipo entidad, y que en base a una propiedad del mismo, identifique dichos objetos.
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);


            modelBuilder.Entity<Client>().HasData( //Declaramos nuestros primeros clientes de nuestro contexto, para la base de datos.
            new Client
            {
                Id = 1,
                Email = "augustocamani@gmail.com",
                UserName = "Enano",
                Password = "1234"

            },
            new Client
            {
                Id = 2,
                Email = "santinocapone@gmail.com",
                UserName = "CaponeCapo",
                Password = "4321"
            },
            new Client
            {
                Id = 3,
                Email = "santiagoferesin@gmail.com",
                UserName = "ElFere",
                Password = "3412"
            }
            );

            modelBuilder.Entity<Admin>().HasData( //Declaramos nuestro primer administrador para la base de datos.
            new Admin
            {
                Id = 4,
                Email = "augustocamaniadmin@gmail.com",
                UserName = "ElSysAdmin",
                Password = "1342"
            });

            modelBuilder.Entity<Product>().HasData( //Declaramos nuestro primer producto para la base de datos.
            new Product
            {
                Id = 1,
                Name = "Guitarra",
                Description = "Guitarra criolla",
                Price = 30000
            }
             );

            modelBuilder.Entity<Client>(entity => //Se configura la entidad.
            {   //No requiere agregar el HasKey() ya que la llave primaria se encuentra en la clase padre.
                entity.ToTable("Users"); //Aquí se le dá nombre a la tabla que tendrá la entidad en la base de datos.Se lo agrega a la tabla USERS ya que hereda de la clase User.
                entity.HasMany(c => c.Sales) //Se especifica el tipo de relación entre la entidades. (En este caso de UNO a MUCHOS).
                    .WithOne(p => p.Client) //Se especifica la relación de la entidad secundaria con la primaria (En este caso de MUCHOS a UNO).
                    .HasForeignKey(p => p.ClientId);//Se especifica la clave foránea de la tabla.
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sales");
                entity.HasKey(e => e.Id);//Se especifica cual es la clave primaria de la tabla.
                entity.HasMany(p => p.SaleLines)
                    .WithOne(pl => pl.Sale)
                    .HasForeignKey(pl => pl.SaleId);
            });

            modelBuilder.Entity<SaleLine>(entity =>
            {
                entity.ToTable("SaleLines");
                entity.HasKey(e => e.Id);
                entity.HasOne(pl => pl.Product)
                    .WithMany(p => p.SaleLines)
                    .HasForeignKey(pl => pl.ProductId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.Id);
                entity.HasMany(p => p.SaleLines)
                    .WithOne(pl => pl.Product)
                    .HasForeignKey(pl => pl.ProductId);
            });

            //Acá le decimos al DbContext que implemente el método para crear el modelo, pasándole el modelo que nostros creamos por parámetro
            base.OnModelCreating(modelBuilder); 
        }
    }
}

