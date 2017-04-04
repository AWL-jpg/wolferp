namespace wolffERPWebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class wolffDBContext : DbContext
    {
        public wolffDBContext()
            : base("name=wolffDB")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<CalibrationTest> CalibrationTests { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerCourier> CustomerCouriers { get; set; }
        public virtual DbSet<CustomerStandard> CustomerStandards { get; set; }
        public virtual DbSet<CustomerStandardTest> CustomerStandardTests { get; set; }
        public virtual DbSet<DeadweightSN> DeadweightSNs { get; set; }
        public virtual DbSet<DropdownItem> DropdownItems { get; set; }
        public virtual DbSet<DropdownType> DropdownTypes { get; set; }
        public virtual DbSet<OxygenCertificate> OxygenCertificates { get; set; }
        public virtual DbSet<ServiceCertificate> ServiceCertificates { get; set; }
        public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }
        public virtual DbSet<ServiceOrderItem> ServiceOrderItems { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorAddress> VendorAddresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.AddressId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Address>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Province)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Street1)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Street2)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.CustomerAddresses)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.VendorAddresses)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CalibrationTest>()
                .Property(e => e.CalibrationTestId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<CalibrationTest>()
                .Property(e => e.UpscaleError)
                .HasPrecision(12, 0);

            modelBuilder.Entity<CalibrationTest>()
                .Property(e => e.TestField)
                .HasPrecision(1, 0);

            modelBuilder.Entity<CalibrationTest>()
                .Property(e => e.CustomerStandardTestId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<CalibrationTest>()
                .Property(e => e.ServiceCertificateId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Contact>()
                .Property(e => e.ContactId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.AddressId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Courier>()
                .Property(e => e.CourierId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Courier>()
                .Property(e => e.AccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .HasMany(e => e.CustomerCouriers)
                .WithRequired(e => e.Courier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerAddresses)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerCouriers)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerAddress>()
                .Property(e => e.CustomerId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<CustomerAddress>()
                .Property(e => e.AddressId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<CustomerAddress>()
                .Property(e => e.AddressType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CustomerCourier>()
                .Property(e => e.CustomerId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<CustomerCourier>()
                .Property(e => e.CourierId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<CustomerCourier>()
                .Property(e => e.Preferred)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CustomerStandard>()
                .Property(e => e.CustomerStandardId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<CustomerStandard>()
                .Property(e => e.CustomerStandardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerStandard>()
                .Property(e => e.TestFields)
                .HasPrecision(1, 0);

            modelBuilder.Entity<CustomerStandard>()
                .Property(e => e.Hidden)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CustomerStandard>()
                .HasMany(e => e.CustomerStandardTests)
                .WithRequired(e => e.CustomerStandard)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerStandardTest>()
                .Property(e => e.CustomerStandardTestId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<CustomerStandardTest>()
                .Property(e => e.TestPercentage)
                .HasPrecision(3, 2);

            modelBuilder.Entity<CustomerStandardTest>()
                .Property(e => e.CustomerStandardId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<DeadweightSN>()
                .Property(e => e.DeadweightSNId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<DeadweightSN>()
                .Property(e => e.SerialNumber)
                .IsUnicode(false);

            modelBuilder.Entity<DeadweightSN>()
                .Property(e => e.Hidden)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DropdownItem>()
                .Property(e => e.DropdownItemId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<DropdownItem>()
                .Property(e => e.DropdownValue)
                .IsUnicode(false);

            modelBuilder.Entity<DropdownItem>()
                .Property(e => e.Hidden)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DropdownItem>()
                .Property(e => e.DropdownTypeId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<DropdownItem>()
                .HasMany(e => e.ServiceOrderItems)
                .WithMany(e => e.DropdownItems)
                .Map(m => m.ToTable("DropdownItemDetail").MapLeftKey("DropdownItemId").MapRightKey("ServiceOrderItemId"));

            modelBuilder.Entity<DropdownType>()
                .Property(e => e.DropdownTypeId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<DropdownType>()
                .Property(e => e.DropdownName)
                .IsUnicode(false);

            modelBuilder.Entity<DropdownType>()
                .Property(e => e.DropdownDataType)
                .IsUnicode(false);

            modelBuilder.Entity<DropdownType>()
                .HasMany(e => e.DropdownItems)
                .WithRequired(e => e.DropdownType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OxygenCertificate>()
                .Property(e => e.OxygenCertificateId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<OxygenCertificate>()
                .Property(e => e.OxygenCertificateNumber)
                .HasPrecision(12, 0);

            modelBuilder.Entity<OxygenCertificate>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.ServiceCertificateId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.CalibrationCertificateNumber)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.Humidity)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.AmbientTemperature)
                .HasPrecision(3, 0);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.MaximumError)
                .HasPrecision(4, 0);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.TestGaugeAccuracy)
                .HasPrecision(6, 2);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.TestMedium)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.Invoice)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.TechnicianId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.QCTechnicianId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceCertificate>()
                .Property(e => e.DeadweightSNId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.ServiceOrderId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.ServiceType)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.Rushed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.PurchaseOrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.SubletPONumber)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.CourierId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.CustomerId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.ContactId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrder>()
                .Property(e => e.VendorId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrder>()
                .HasMany(e => e.ServiceOrderItems)
                .WithRequired(e => e.ServiceOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.ServiceOrderitemId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.SerialNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.Service)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.Fittings)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.Hidden)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.CustomerStandardId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.ServiceOrderId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.OxygenCertificateId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ServiceOrderItem>()
                .Property(e => e.ServiceCertificateId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.VendorAddresses)
                .WithRequired(e => e.Vendor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendorAddress>()
                .Property(e => e.VendorId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<VendorAddress>()
                .Property(e => e.AddressId)
                .HasPrecision(12, 0);

            modelBuilder.Entity<VendorAddress>()
                .Property(e => e.AddressType)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
