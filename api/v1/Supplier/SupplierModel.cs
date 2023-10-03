namespace Movie_Server.Models {
    public class SupplierCreateModel {
        public string SlName { get; set; } = null!;

        public string SlEmail { get; set; } = null!;

        public string SlPhone { get; set; } = null!;

        public string SlAddress { get; set; } = null!;

 
    }
    public class SupplierUpdateModel {
        public string SlName { get; set; } = null!;

        public string SlPhone { get; set; } = null!;

        public string SlAddress { get; set; } = null!;

    }
}