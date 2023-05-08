using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Platinum_Island_API.Models
{
    public partial class Platinum_Island_DatabaseContext : DbContext
    {
        public Platinum_Island_DatabaseContext()
        {
        }

        public Platinum_Island_DatabaseContext(DbContextOptions<Platinum_Island_DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<DayVisit> DayVisits { get; set; } = null!;
        public virtual DbSet<DayVisitDate> DayVisitDates { get; set; } = null!;
        public virtual DbSet<DayVisitPayment> DayVisitPayments { get; set; } = null!;
        public virtual DbSet<DayVisitPaymentType> DayVisitPaymentTypes { get; set; } = null!;
        public virtual DbSet<DayVisitRefund> DayVisitRefunds { get; set; } = null!;
        public virtual DbSet<DayVisitStatus> DayVisitStatuses { get; set; } = null!;
        public virtual DbSet<DayVisitTicket> DayVisitTickets { get; set; } = null!;
        public virtual DbSet<DayVisitTicketPrice> DayVisitTicketPrices { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventPayment> EventPayments { get; set; } = null!;
        public virtual DbSet<EventPaymentType> EventPaymentTypes { get; set; } = null!;
        public virtual DbSet<EventRefund> EventRefunds { get; set; } = null!;
        public virtual DbSet<EventStatus> EventStatuses { get; set; } = null!;
        public virtual DbSet<EventTicket> EventTickets { get; set; } = null!;
        public virtual DbSet<InspectionStatus> InspectionStatuses { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemCategory> ItemCategories { get; set; } = null!;
        public virtual DbSet<ItemPrice> ItemPrices { get; set; } = null!;
        public virtual DbSet<ItemType> ItemTypes { get; set; } = null!;
        public virtual DbSet<OrderLine> OrderLines { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<RecieveSupplierOrder> RecieveSupplierOrders { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomBooking> RoomBookings { get; set; } = null!;
        public virtual DbSet<RoomBookingRefund> RoomBookingRefunds { get; set; } = null!;
        public virtual DbSet<RoomBookingStatus> RoomBookingStatuses { get; set; } = null!;
        public virtual DbSet<RoomDate> RoomDates { get; set; } = null!;
        public virtual DbSet<RoomDateTime> RoomDateTimes { get; set; } = null!;
        public virtual DbSet<RoomInspection> RoomInspections { get; set; } = null!;
        public virtual DbSet<RoomInspectionWriteOff> RoomInspectionWriteOffs { get; set; } = null!;
        public virtual DbSet<RoomPayment> RoomPayments { get; set; } = null!;
        public virtual DbSet<RoomPaymentType> RoomPaymentTypes { get; set; } = null!;
        public virtual DbSet<RoomStatus> RoomStatuses { get; set; } = null!;
        public virtual DbSet<RoomTime> RoomTimes { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<RoomTypePrice> RoomTypePrices { get; set; } = null!;
        public virtual DbSet<RsoLine> RsoLines { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierOrder> SupplierOrders { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vat> Vats { get; set; } = null!;
        public virtual DbSet<Venue> Venues { get; set; } = null!;
        public virtual DbSet<VenueDate> VenueDates { get; set; } = null!;
        public virtual DbSet<VenueDateTime> VenueDateTimes { get; set; } = null!;
        public virtual DbSet<VenueInspection> VenueInspections { get; set; } = null!;
        public virtual DbSet<VenueInspectionWriteOff> VenueInspectionWriteOffs { get; set; } = null!;
        public virtual DbSet<VenuePrice> VenuePrices { get; set; } = null!;
        public virtual DbSet<VenueStatus> VenueStatuses { get; set; } = null!;
        public virtual DbSet<VenueTime> VenueTimes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-R7R4GE34;Database=Platinum_Island_Database;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("AuditLog");

                entity.Property(e => e.AuditLogId).HasColumnName("AuditLog_ID");

                entity.Property(e => e.DateOfChange).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AuditLogs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AuditLog__Employ__37A5467C");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClientEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientIdnum)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ClientIDNum");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLientName");

                entity.Property(e => e.ClientPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClientSurname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClientUserId).HasColumnName("Client_UserID");

                entity.HasOne(d => d.ClientUser)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientUserId)
                    .HasConstraintName("FK__Client__Client_U__29572725");
            });

            modelBuilder.Entity<DayVisit>(entity =>
            {
                entity.ToTable("DayVisit");

                entity.Property(e => e.DayVisitId).HasColumnName("DayVisit_ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DayVisitDateId).HasColumnName("DayVisitDate_ID");

                entity.Property(e => e.DayVisitStatusId).HasColumnName("DayVisitStatus_ID");

                entity.Property(e => e.Total).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DayVisits)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__DayVisit__Client__3F466844");

                entity.HasOne(d => d.DayVisitDate)
                    .WithMany(p => p.DayVisits)
                    .HasForeignKey(d => d.DayVisitDateId)
                    .HasConstraintName("FK__DayVisit__DayVis__403A8C7D");

                entity.HasOne(d => d.DayVisitStatus)
                    .WithMany(p => p.DayVisits)
                    .HasForeignKey(d => d.DayVisitStatusId)
                    .HasConstraintName("FK__DayVisit__DayVis__3E52440B");
            });

            modelBuilder.Entity<DayVisitDate>(entity =>
            {
                entity.ToTable("DayVisitDate");

                entity.Property(e => e.DayVisitDateId).HasColumnName("DayVisitDate_ID");

                entity.Property(e => e.DayVisitDate1)
                    .HasColumnType("date")
                    .HasColumnName("DayVisitDate");
            });

            modelBuilder.Entity<DayVisitPayment>(entity =>
            {
                entity.ToTable("DayVisitPayment");

                entity.Property(e => e.DayVisitPaymentId).HasColumnName("DayVisitPayment_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.DayVisitId).HasColumnName("DayVisit_ID");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentType_ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DayVisitPayments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__DayVisitP__Clien__4AB81AF0");

                entity.HasOne(d => d.DayVisit)
                    .WithMany(p => p.DayVisitPayments)
                    .HasForeignKey(d => d.DayVisitId)
                    .HasConstraintName("FK__DayVisitP__DayVi__4BAC3F29");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.DayVisitPayments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK__DayVisitP__Payme__4CA06362");
            });

            modelBuilder.Entity<DayVisitPaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId)
                    .HasName("PK__DayVisit__CD8B7D19EA8BF2AE");

                entity.ToTable("DayVisitPaymentType");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentType_ID");

                entity.Property(e => e.TypeDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DayVisitRefund>(entity =>
            {
                entity.HasKey(e => e.RefundId)
                    .HasName("PK__DayVisit__9F95781F00189EAD");

                entity.ToTable("DayVisitRefund");

                entity.Property(e => e.RefundId).HasColumnName("Refund_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DayVisitId).HasColumnName("DayVisitID");

                entity.HasOne(d => d.DayVisit)
                    .WithMany(p => p.DayVisitRefunds)
                    .HasForeignKey(d => d.DayVisitId)
                    .HasConstraintName("FK__DayVisitR__DayVi__4F7CD00D");
            });

            modelBuilder.Entity<DayVisitStatus>(entity =>
            {
                entity.ToTable("DayVisitStatus");

                entity.Property(e => e.DayVisitStatusId).HasColumnName("DayVisitStatus_ID");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DayVisitTicket>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__DayVisit__ED7260D9AC4C2985");

                entity.ToTable("DayVisitTicket");

                entity.Property(e => e.TicketId).HasColumnName("Ticket_ID");

                entity.Property(e => e.DayVisitId).HasColumnName("DayVisit_ID");

                entity.Property(e => e.GuestName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Qrcode).HasColumnName("QRCode");

                entity.HasOne(d => d.DayVisit)
                    .WithMany(p => p.DayVisitTickets)
                    .HasForeignKey(d => d.DayVisitId)
                    .HasConstraintName("FK__DayVisitT__DayVi__4316F928");
            });

            modelBuilder.Entity<DayVisitTicketPrice>(entity =>
            {
                entity.HasKey(e => e.PriceId)
                    .HasName("PK__DayVisit__A4821BF2A3726E31");

                entity.ToTable("DayVisitTicketPrice");

                entity.Property(e => e.PriceId).HasColumnName("Price_ID");

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PriceDate).HasColumnType("date");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.DayVisitTicketPrices)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK__DayVisitT__Ticke__45F365D3");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeTypeId).HasColumnName("Employee_TypeID");

                entity.Property(e => e.EmployeeUserId).HasColumnName("Employee_UserID");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .HasConstraintName("FK__Employee__Employ__2E1BDC42");

                entity.HasOne(d => d.EmployeeUser)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Employ__2F10007B");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("EmployeeType");

                entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeType_ID");

                entity.Property(e => e.TypeDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EventId).HasColumnName("Event_ID");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EventStatusId).HasColumnName("EventStatusID");

                entity.Property(e => e.Total).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Event__Client_ID__778AC167");

                entity.HasOne(d => d.EventStatus)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventStatusId)
                    .HasConstraintName("FK__Event__EventStat__76969D2E");
            });

            modelBuilder.Entity<EventPayment>(entity =>
            {
                entity.ToTable("EventPayment");

                entity.Property(e => e.EventPaymentId).HasColumnName("EventPayment_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.EventPayments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__EventPaym__Clien__10566F31");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.EventPayments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK__EventPaym__Payme__114A936A");
            });

            modelBuilder.Entity<EventPaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId)
                    .HasName("PK__EventPay__CD8B7D19ACFFBA36");

                entity.ToTable("EventPaymentType");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentType_ID");

                entity.Property(e => e.TypeDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventRefund>(entity =>
            {
                entity.HasKey(e => e.RefundId)
                    .HasName("PK__EventRef__9F95781F0E7BFC7B");

                entity.ToTable("EventRefund");

                entity.Property(e => e.RefundId).HasColumnName("Refund_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventRefunds)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__EventRefu__Event__14270015");
            });

            modelBuilder.Entity<EventStatus>(entity =>
            {
                entity.ToTable("EventStatus");

                entity.Property(e => e.EventStatusId).HasColumnName("EventStatus_ID");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventTicket>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__EventTic__ED7260D99125835F");

                entity.ToTable("EventTicket");

                entity.Property(e => e.TicketId).HasColumnName("Ticket_ID");

                entity.Property(e => e.EventId).HasColumnName("Event_ID");

                entity.Property(e => e.GuestName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.QrCode).HasColumnName("Qr_Code");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventTickets)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__EventTick__Event__7A672E12");
            });

            modelBuilder.Entity<InspectionStatus>(entity =>
            {
                entity.ToTable("InspectionStatus");

                entity.Property(e => e.InspectionStatusId).HasColumnName("InspectionStatus_ID");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemId).HasColumnName("Item_ID");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemTypeId)
                    .HasConstraintName("FK__Item__ItemTypeID__1BC821DD");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.ToTable("ItemCategory");

                entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategory_ID");

                entity.Property(e => e.CategoryDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemPrice>(entity =>
            {
                entity.ToTable("ItemPrice");

                entity.Property(e => e.ItemPriceId).HasColumnName("ItemPrice_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.PriceDate).HasColumnType("datetime");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemPrices)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__ItemPrice__ItemI__1EA48E88");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType");

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemType_ID");

                entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategoryID");

                entity.Property(e => e.TypeDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.ItemTypes)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK__ItemType__ItemCa__18EBB532");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.ToTable("OrderLine");

                entity.Property(e => e.OrderLineId).HasColumnName("OrderLine_ID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderTotal)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("Order_Total");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__OrderLine__ItemI__2739D489");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderLine__Order__282DF8C2");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.PermissionId).HasColumnName("Permission_ID");

                entity.Property(e => e.PermissionDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecieveSupplierOrder>(entity =>
            {
                entity.HasKey(e => e.RsoId)
                    .HasName("PK__RecieveS__8D1D95E3A8718EA5");

                entity.ToTable("RecieveSupplierOrder");

                entity.Property(e => e.RsoId).HasColumnName("RSO_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.RsoDate)
                    .HasColumnType("datetime")
                    .HasColumnName("RSO_Date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RecieveSupplierOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__RecieveSu__Emplo__2B0A656D");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.ReviewId).HasColumnName("Review_ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DayVisitId).HasColumnName("DayVisitID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ReviewDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoomBookingId).HasColumnName("RoomBookingID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Review__ClientID__46B27FE2");

                entity.HasOne(d => d.DayVisit)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.DayVisitId)
                    .HasConstraintName("FK__Review__DayVisit__47A6A41B");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Review__EventID__489AC854");

                entity.HasOne(d => d.RoomBooking)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.RoomBookingId)
                    .HasConstraintName("FK__Review__RoomBook__498EEC8D");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId })
                    .HasName("PK__RolePerm__9091C0D5177B79CF");

                entity.ToTable("RolePermission");

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.PermissionId).HasColumnName("Permission_ID");

                entity.Property(e => e.Rpdescription)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RPDescription");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RolePermi__Permi__34C8D9D1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RolePermi__Role___33D4B598");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                entity.Property(e => e.RoomFloor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomType_ID");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__Room__RoomType_I__571DF1D5");
            });

            modelBuilder.Entity<RoomBooking>(entity =>
            {
                entity.ToTable("RoomBooking");

                entity.Property(e => e.RoomBookingId).HasColumnName("RoomBooking_ID");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoomBookingStatusId).HasColumnName("RoomBookingStatusID");

                entity.HasOne(d => d.RoomBookingStatus)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.RoomBookingStatusId)
                    .HasConstraintName("FK__RoomBooki__RoomB__619B8048");
            });

            modelBuilder.Entity<RoomBookingRefund>(entity =>
            {
                entity.HasKey(e => e.RefundId)
                    .HasName("PK__RoomBook__9F95781FF8213750");

                entity.ToTable("RoomBookingRefund");

                entity.Property(e => e.RefundId).HasColumnName("Refund_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RoomBookingId).HasColumnName("RoomBookingID");

                entity.HasOne(d => d.RoomBooking)
                    .WithMany(p => p.RoomBookingRefunds)
                    .HasForeignKey(d => d.RoomBookingId)
                    .HasConstraintName("FK__RoomBooki__RoomB__71D1E811");
            });

            modelBuilder.Entity<RoomBookingStatus>(entity =>
            {
                entity.ToTable("RoomBookingStatus");

                entity.Property(e => e.RoomBookingStatusId).HasColumnName("RoomBookingStatus_ID");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomDate>(entity =>
            {
                entity.ToTable("RoomDate");

                entity.Property(e => e.RoomDateId).HasColumnName("RoomDate_ID");

                entity.Property(e => e.RoomDate1)
                    .HasColumnType("date")
                    .HasColumnName("Room_Date");
            });

            modelBuilder.Entity<RoomDateTime>(entity =>
            {
                entity.HasKey(e => new { e.DateId, e.TimeId })
                    .HasName("PK__RoomDate__AA49AD693045D570");

                entity.ToTable("RoomDateTime");

                entity.Property(e => e.DateId).HasColumnName("Date_ID");

                entity.Property(e => e.TimeId).HasColumnName("Time_ID");

                entity.Property(e => e.RoomBookingId).HasColumnName("RoomBookingID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.RoomStatusId).HasColumnName("RoomStatusID");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.RoomDateTimes)
                    .HasForeignKey(d => d.DateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoomDateT__Date___6477ECF3");

                entity.HasOne(d => d.RoomBooking)
                    .WithMany(p => p.RoomDateTimes)
                    .HasForeignKey(d => d.RoomBookingId)
                    .HasConstraintName("FK__RoomDateT__RoomB__66603565");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomDateTimes)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__RoomDateT__RoomI__6754599E");

                entity.HasOne(d => d.RoomStatus)
                    .WithMany(p => p.RoomDateTimes)
                    .HasForeignKey(d => d.RoomStatusId)
                    .HasConstraintName("FK__RoomDateT__RoomS__68487DD7");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.RoomDateTimes)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoomDateT__Time___656C112C");
            });

            modelBuilder.Entity<RoomInspection>(entity =>
            {
                entity.ToTable("RoomInspection");

                entity.Property(e => e.RoomInspectionId).HasColumnName("RoomInspection_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.InspectionDate).HasColumnType("datetime");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RoomInspections)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__RoomInspe__Emplo__3493CFA7");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomInspections)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__RoomInspe__RoomI__339FAB6E");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.RoomInspections)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__RoomInspe__Statu__3587F3E0");
            });

            modelBuilder.Entity<RoomInspectionWriteOff>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.InspectionId })
                    .HasName("PK__RoomInsp__CA6AC1680DD26E8D");

                entity.ToTable("RoomInspectionWriteOff");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.InspectionId).HasColumnName("Inspection_ID");

                entity.Property(e => e.WriteOffDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WriteOffImage).HasColumnType("image");

                entity.HasOne(d => d.Inspection)
                    .WithMany(p => p.RoomInspectionWriteOffs)
                    .HasForeignKey(d => d.InspectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoomInspe__Inspe__395884C4");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.RoomInspectionWriteOffs)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoomInspe__ItemI__3864608B");
            });

            modelBuilder.Entity<RoomPayment>(entity =>
            {
                entity.ToTable("RoomPayment");

                entity.Property(e => e.RoomPaymentId).HasColumnName("RoomPayment_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.RoomBookingId).HasColumnName("RoomBookingID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.RoomPayments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__RoomPayme__Clien__6D0D32F4");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.RoomPayments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK__RoomPayme__Payme__6EF57B66");

                entity.HasOne(d => d.RoomBooking)
                    .WithMany(p => p.RoomPayments)
                    .HasForeignKey(d => d.RoomBookingId)
                    .HasConstraintName("FK__RoomPayme__RoomB__6E01572D");
            });

            modelBuilder.Entity<RoomPaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId)
                    .HasName("PK__RoomPaym__CD8B7D19EE184966");

                entity.ToTable("RoomPaymentType");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentType_ID");

                entity.Property(e => e.TypeDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomStatus>(entity =>
            {
                entity.ToTable("RoomStatus");

                entity.Property(e => e.RoomStatusId).HasColumnName("RoomStatus_ID");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomTime>(entity =>
            {
                entity.ToTable("RoomTime");

                entity.Property(e => e.RoomTimeId).HasColumnName("RoomTime_ID");

                entity.Property(e => e.RoomTime1).HasColumnName("Room_Time");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType");

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomType_ID");

                entity.Property(e => e.TypeDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomTypePrice>(entity =>
            {
                entity.HasKey(e => e.RoomPriceId)
                    .HasName("PK__RoomType__9EAD5E733D75AD32");

                entity.ToTable("RoomTypePrice");

                entity.Property(e => e.RoomPriceId).HasColumnName("RoomPrice_ID");

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PriceDate).HasColumnType("date");

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomType_ID");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.RoomTypePrices)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__RoomTypeP__RoomT__5441852A");
            });

            modelBuilder.Entity<RsoLine>(entity =>
            {
                entity.HasKey(e => new { e.Rsoid, e.OrderLineId })
                    .HasName("PK__RSO_Line__8B1AA9BD0432A2E4");

                entity.ToTable("RSO_Line");

                entity.Property(e => e.Rsoid).HasColumnName("RSOID");

                entity.Property(e => e.OrderLineId).HasColumnName("OrderLineID");

                entity.HasOne(d => d.OrderLine)
                    .WithMany(p => p.RsoLines)
                    .HasForeignKey(d => d.OrderLineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RSO_Line__OrderL__2EDAF651");

                entity.HasOne(d => d.Rso)
                    .WithMany(p => p.RsoLines)
                    .HasForeignKey(d => d.Rsoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RSO_Line__RSOID__2DE6D218");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.Property(e => e.SupplierEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_Name");

                entity.Property(e => e.SupplierPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SupplierOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Supplier__F1E4639B92279FB9");

                entity.ToTable("SupplierOrder");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SupplierOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__SupplierO__Emplo__245D67DE");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__SupplierO__Suppl__236943A5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleId).HasColumnName("User_RoleID");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK__Users__User_Role__267ABA7A");
            });

            modelBuilder.Entity<Vat>(entity =>
            {
                entity.ToTable("VAT");

                entity.Property(e => e.VatId).HasColumnName("VAT_ID");

                entity.Property(e => e.VatAmount)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("VAT_Amount");

                entity.Property(e => e.VatDate)
                    .HasColumnType("datetime")
                    .HasColumnName("VAT_Date");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("Venue");

                entity.Property(e => e.VenueId).HasColumnName("Venue_ID");

                entity.Property(e => e.VenueDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VenueName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VenueDate>(entity =>
            {
                entity.ToTable("VenueDate");

                entity.Property(e => e.VenueDateId).HasColumnName("VenueDate_ID");

                entity.Property(e => e.VenueDate1)
                    .HasColumnType("date")
                    .HasColumnName("Venue_Date");
            });

            modelBuilder.Entity<VenueDateTime>(entity =>
            {
                entity.HasKey(e => new { e.DateId, e.TimeId })
                    .HasName("PK__VenueDat__AA49AD6973FD4D5B");

                entity.ToTable("VenueDateTime");

                entity.Property(e => e.DateId).HasColumnName("Date_ID");

                entity.Property(e => e.TimeId).HasColumnName("Time_ID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.Property(e => e.VenueStatusId).HasColumnName("VenueStatusID");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.VenueDateTimes)
                    .HasForeignKey(d => d.DateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VenueDate__Date___07C12930");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.VenueDateTimes)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__VenueDate__Event__0B91BA14");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.VenueDateTimes)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VenueDate__Time___08B54D69");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.VenueDateTimes)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("FK__VenueDate__Venue__09A971A2");

                entity.HasOne(d => d.VenueStatus)
                    .WithMany(p => p.VenueDateTimes)
                    .HasForeignKey(d => d.VenueStatusId)
                    .HasConstraintName("FK__VenueDate__Venue__0A9D95DB");
            });

            modelBuilder.Entity<VenueInspection>(entity =>
            {
                entity.ToTable("VenueInspection");

                entity.Property(e => e.VenueInspectionId).HasColumnName("VenueInspection_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.InspectionDate).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.VenueInspections)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__VenueInsp__Emplo__3D2915A8");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.VenueInspections)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__VenueInsp__Statu__3E1D39E1");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.VenueInspections)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("FK__VenueInsp__Venue__3C34F16F");
            });

            modelBuilder.Entity<VenueInspectionWriteOff>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.InspectionId })
                    .HasName("PK__VenueIns__CA6AC168B9C43B10");

                entity.ToTable("VenueInspectionWriteOff");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.InspectionId).HasColumnName("Inspection_ID");

                entity.Property(e => e.WriteOffDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WriteOffImage).HasColumnType("image");

                entity.HasOne(d => d.Inspection)
                    .WithMany(p => p.VenueInspectionWriteOffs)
                    .HasForeignKey(d => d.InspectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VenueInsp__Inspe__41EDCAC5");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.VenueInspectionWriteOffs)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VenueInsp__ItemI__40F9A68C");
            });

            modelBuilder.Entity<VenuePrice>(entity =>
            {
                entity.ToTable("VenuePrice");

                entity.Property(e => e.VenuePriceId).HasColumnName("VenuePrice_ID");

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PriceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Price_Date");

                entity.Property(e => e.VenueId).HasColumnName("Venue_ID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.VenuePrices)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("FK__VenuePric__Venue__04E4BC85");
            });

            modelBuilder.Entity<VenueStatus>(entity =>
            {
                entity.ToTable("VenueStatus");

                entity.Property(e => e.VenueStatusId).HasColumnName("VenueStatus_ID");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VenueTime>(entity =>
            {
                entity.ToTable("VenueTime");

                entity.Property(e => e.VenueTimeId).HasColumnName("VenueTime_ID");

                entity.Property(e => e.VenueTime1).HasColumnName("Venue_Time");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
