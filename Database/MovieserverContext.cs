using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Movie_Server.Database.Models;

public partial class MovieserverContext : DbContext
{
    public MovieserverContext()
    {
    }

    public MovieserverContext(DbContextOptions<MovieserverContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<ListMovie> ListMovies { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieCategoty> MovieCategoties { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Refreshtoken> Refreshtokens { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFavourite> UserFavourites { get; set; }

    public virtual DbSet<UserMovie> UserMovies { get; set; }

    public virtual DbSet<UserVoucher> UserVouchers { get; set; }

    public virtual DbSet<Vnpay> Vnpays { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=movieserver;uid=root;pwd=123456789", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CateName)
                .HasMaxLength(255)
                .HasColumnName("cate_name");
            entity.Property(e => e.CateType).HasColumnName("cate_type");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lists");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.Genre)
                .HasMaxLength(200)
                .HasColumnName("genre");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ListMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("list_movies");

            entity.HasIndex(e => e.LmListId, "lm_list_id");

            entity.HasIndex(e => e.LmMovieId, "lm_movie_id");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.LmListId)
                .HasMaxLength(50)
                .HasColumnName("lm_list_id");
            entity.Property(e => e.LmMovieId)
                .HasMaxLength(50)
                .HasColumnName("lm_movie_id");

            entity.HasOne(d => d.LmList).WithMany(p => p.ListMovies)
                .HasForeignKey(d => d.LmListId)
                .HasConstraintName("list_movies_ibfk_1");

            entity.HasOne(d => d.LmMovie).WithMany(p => p.ListMovies)
                .HasForeignKey(d => d.LmMovieId)
                .HasConstraintName("list_movies_ibfk_2");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movie");

            entity.HasIndex(e => e.SupplierId, "supplier_id");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Clicked).HasColumnName("clicked");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.Desc)
                .HasColumnType("text")
                .HasColumnName("_desc");
            entity.Property(e => e.Img)
                .HasColumnType("text")
                .HasColumnName("img");
            entity.Property(e => e.ImgSm)
                .HasColumnType("text")
                .HasColumnName("imgSm");
            entity.Property(e => e.IsSeries)
                .HasDefaultValueSql("'0'")
                .HasColumnName("isSeries");
            entity.Property(e => e.Limit).HasColumnName("_limit");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("supplier_id");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
            entity.Property(e => e.Trailer)
                .HasColumnType("text")
                .HasColumnName("trailer");
            entity.Property(e => e.Video)
                .HasColumnType("text")
                .HasColumnName("video");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Movies)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("movie_ibfk_1");
        });

        modelBuilder.Entity<MovieCategoty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movie_categoties");

            entity.HasIndex(e => e.MvCateId, "mv_cate_id");

            entity.HasIndex(e => e.MvMovieId, "mv_movie_id");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.MvCateId)
                .HasMaxLength(50)
                .HasColumnName("mv_cate_id");
            entity.Property(e => e.MvMovieId)
                .HasMaxLength(500)
                .HasColumnName("mv_movie_id");

            entity.HasOne(d => d.MvCate).WithMany(p => p.MovieCategoties)
                .HasForeignKey(d => d.MvCateId)
                .HasConstraintName("movie_categoties_ibfk_2");

            entity.HasOne(d => d.MvMovie).WithMany(p => p.MovieCategoties)
                .HasForeignKey(d => d.MvMovieId)
                .HasConstraintName("movie_categoties_ibfk_1");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ratings");

            entity.HasIndex(e => e.RMovieId, "r_movie_id");

            entity.HasIndex(e => e.RUserId, "r_user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.RContent)
                .HasColumnType("text")
                .HasColumnName("r_content");
            entity.Property(e => e.RMovieId)
                .HasMaxLength(50)
                .HasColumnName("r_movie_id");
            entity.Property(e => e.RNumberStar)
                .HasDefaultValueSql("'0'")
                .HasColumnName("r_number_star");
            entity.Property(e => e.RUserId)
                .HasMaxLength(50)
                .HasColumnName("r_user_id");

            entity.HasOne(d => d.RMovie).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.RMovieId)
                .HasConstraintName("ratings_ibfk_2");

            entity.HasOne(d => d.RUser).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.RUserId)
                .HasConstraintName("ratings_ibfk_1");
        });

        modelBuilder.Entity<Refreshtoken>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("refreshtoken");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("user_id");
            entity.Property(e => e.RefreshToke)
                .HasMaxLength(500)
                .HasColumnName("refresh_toke");
            entity.Property(e => e.TokenId)
                .HasMaxLength(50)
                .HasColumnName("token_id");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.SlAddress)
                .HasColumnType("text")
                .HasColumnName("sl_address");
            entity.Property(e => e.SlEmail)
                .HasMaxLength(255)
                .HasColumnName("sl_email");
            entity.Property(e => e.SlName)
                .HasMaxLength(255)
                .HasColumnName("sl_name");
            entity.Property(e => e.SlPhone)
                .HasMaxLength(255)
                .HasColumnName("sl_phone");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.FaceId)
                .HasColumnType("text")
                .HasColumnName("face_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("'1'")
                .HasColumnName("isActive");
            entity.Property(e => e.MoneySpended)
                .HasDefaultValueSql("'0'")
                .HasColumnName("money_spended");
            entity.Property(e => e.Password)
                .HasColumnType("text")
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasColumnType("text")
                .HasColumnName("phone");
            entity.Property(e => e.Point)
                .HasDefaultValueSql("'0'")
                .HasColumnName("point");
            entity.Property(e => e.ProfilePic)
                .HasColumnType("text")
                .HasColumnName("profilePic");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasDefaultValueSql("'user'")
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasDefaultValueSql("_utf8mb4\\'user\\'")
                .HasColumnName("username");
            entity.Property(e => e.WalletBalance)
                .HasDefaultValueSql("'0'")
                .HasColumnName("wallet_balance");
        });

        modelBuilder.Entity<UserFavourite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_favourites");

            entity.HasIndex(e => e.UfMovieId, "uf_movie_id");

            entity.HasIndex(e => e.UfUserId, "uf_user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.UfMovieId)
                .HasMaxLength(50)
                .HasColumnName("uf_movie_id");
            entity.Property(e => e.UfUserId)
                .HasMaxLength(50)
                .HasColumnName("uf_user_id");

            entity.HasOne(d => d.UfMovie).WithMany(p => p.UserFavourites)
                .HasForeignKey(d => d.UfMovieId)
                .HasConstraintName("user_favourites_ibfk_2");

            entity.HasOne(d => d.UfUser).WithMany(p => p.UserFavourites)
                .HasForeignKey(d => d.UfUserId)
                .HasConstraintName("user_favourites_ibfk_1");
        });

        modelBuilder.Entity<UserMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_movies");

            entity.HasIndex(e => e.UmMovieId, "um_movie_id");

            entity.HasIndex(e => e.UmUserId, "um_user_id");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.UmMovieId)
                .HasMaxLength(50)
                .HasColumnName("um_movie_id");
            entity.Property(e => e.UmUserId)
                .HasMaxLength(50)
                .HasColumnName("um_user_id");

            entity.HasOne(d => d.UmMovie).WithMany(p => p.UserMovies)
                .HasForeignKey(d => d.UmMovieId)
                .HasConstraintName("user_movies_ibfk_2");

            entity.HasOne(d => d.UmUser).WithMany(p => p.UserMovies)
                .HasForeignKey(d => d.UmUserId)
                .HasConstraintName("user_movies_ibfk_1");
        });

        modelBuilder.Entity<UserVoucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_vouchers");

            entity.HasIndex(e => e.UvUserId, "uv_user_id");

            entity.HasIndex(e => e.UvVoucherId, "uv_voucher_id");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.UvUserId)
                .HasMaxLength(50)
                .HasColumnName("uv_user_id");
            entity.Property(e => e.UvVoucherId)
                .HasMaxLength(50)
                .HasColumnName("uv_voucher_id");

            entity.HasOne(d => d.UvUser).WithMany(p => p.UserVouchers)
                .HasForeignKey(d => d.UvUserId)
                .HasConstraintName("user_vouchers_ibfk_1");

            entity.HasOne(d => d.UvVoucher).WithMany(p => p.UserVouchers)
                .HasForeignKey(d => d.UvVoucherId)
                .HasConstraintName("user_vouchers_ibfk_2");
        });

        modelBuilder.Entity<Vnpay>(entity =>
        {
            entity.HasKey(e => e.VnpayId).HasName("PRIMARY");

            entity.ToTable("vnpay");

            entity.Property(e => e.VnpayId)
                .HasMaxLength(50)
                .HasColumnName("vnpay_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.VnpAmount)
                .HasColumnType("text")
                .HasColumnName("vnp_amount");
            entity.Property(e => e.VnpBankCode)
                .HasColumnType("text")
                .HasColumnName("vnp_BankCode");
            entity.Property(e => e.VnpBankTranNo)
                .HasColumnType("text")
                .HasColumnName("vnp_BankTranNo");
            entity.Property(e => e.VnpCardType)
                .HasColumnType("text")
                .HasColumnName("vnp_CardType");
            entity.Property(e => e.VnpOrderInfo)
                .HasColumnType("text")
                .HasColumnName("vnp_OrderInfo");
            entity.Property(e => e.VnpPayDate)
                .HasColumnType("text")
                .HasColumnName("vnp_PayDate");
            entity.Property(e => e.VnpTmnCode)
                .HasColumnType("text")
                .HasColumnName("vnp_TmnCode");
            entity.Property(e => e.VnpTransactionNo)
                .HasColumnType("text")
                .HasColumnName("vnp_TransactionNo");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vouchers");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.PercentDiscount).HasColumnName("percent_discount");
            entity.Property(e => e.PointCost)
                .HasDefaultValueSql("'0'")
                .HasColumnName("point_cost");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .HasColumnName("supplier_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
