using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Web;
using HelenaGerber_Promo.Utils;

namespace HelenaGerber_Promo.Models.HGStore
{
    public class HGStoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ImageStore> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }
        public DbSet<ProductColor> Colors { get; set; }


        public HGStoreDbContext()
            : base("name=HGStoreDb")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DisplayName("Категория")]
        public int CategoryId { get; set; }

        [DisplayName("Артикуль")]
        public int SKU { get; set; }

        public int ImageStoreId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("ImageStoreId")]
        public virtual ImageStore ImageStore { get; set; }
    }

    public class ImageStore
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Основной рисунок")]
        public string FileName1 { get; set; }

        [DisplayName("Дополнительный рисунок 1")]
        public string FileName2 { get; set; }

        [DisplayName("Дополнительный рисунок 2")]
        public string FileName3 { get; set; }

        public static ImageStore Create(IList<HttpPostedFileBase> files)
        {
            var imageStore = new ImageStore();

            string filename = ImageUtils.GenerateTempFileName(files[0].ContentType);
            files[0].SaveAs(filename);
            imageStore.FileName1 = filename;

            filename = ImageUtils.GenerateTempFileName(files[1].ContentType);
            files[1].SaveAs(filename);
            imageStore.FileName2 = filename;

            filename = ImageUtils.GenerateTempFileName(files[2].ContentType);
            files[2].SaveAs(filename);
            imageStore.FileName3 = filename;

            return imageStore;
        }
    }

    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Категория")]
        public string Name { get; set; }
    }

    public class Description
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Идентификатор товара")]
        public int ProductId { get; set; }

        [DisplayName("Тип")]
        public int TypeId { get; set; }

        [DisplayName("Модель")]
        public int ModelId { get; set; }

        [DisplayName("Размер")]
        public int SizeId { get; set; }

        [DisplayName("Цвет")]
        public int ColorId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("TypeId")]
        public virtual ProductType Type { get; set; }

        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }

        [ForeignKey("SizeId")]
        public virtual ProductSize Size { get; set; }

        [ForeignKey("ColorId")]
        public virtual ProductColor Color { get; set; }
    }

    public class ProductType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Тип")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
    }

    public class Model
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Модель")]
        public string Name { get; set; }

        [DisplayName("Назначение")]
        public string Goal { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
    }

    /// <summary>
    /// Состав продукта
    /// </summary>
    public class Fabric
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Товар")]
        public int ProductId { get; set; }

        [DisplayName("Материал")]
        public int MaterialId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }

        [DisplayName("Процент содержания")]
        public decimal Сontents { get; set; }
    }

    public class Material
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Материал")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Страна производителя")]
        public string Country { get; set; }
    }

    public class ProductSize
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Ширина")]
        public decimal Width { get; set; }

        [DisplayName("Длина")]
        public decimal Height { get; set; }
    }

    public class ProductColor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Цвет")]
        public string Name { get; set; }
    }
}