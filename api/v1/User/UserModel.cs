namespace Movie_Server.Models {
      public class UserModel {

        public string Id { get; set; } = null!;

        public string? Username { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? ProfilePic { get; set; }

        public double? WalletBalance { get; set; }

        public double? Point { get; set; }

        public double? MoneySpended { get; set; }

        public string? Phone { get; set; }

        public bool? IsAdmin { get; set; }

        public string? FaceId { get; set; }

        public DateTime CreateAt { get; set; }


      }
      public class UserCreateModel {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public double? WalletBalance { get; set; }
        public string? Phone { get; set; }
        public bool? IsAdmin { get; set; }

      }

      public class UserUpdateModel {
        public string? Username { get; set; }

        public string Password { get; set; } = null!;

        public string? ProfilePic { get; set; }

        public double? WalletBalance { get; set; }

        public string? Phone { get; set; }

        public bool? IsAdmin { get; set; }

      }
}