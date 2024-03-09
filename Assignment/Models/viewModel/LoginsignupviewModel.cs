namespace Assignment.Models.viewModel
{
    public class LoginsignupviewModel
    {
        public int Id { get; set; }



        public string User_Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string phone { get; set; }
        public bool isActive { get; set; }


        public bool IsRemember { get; set; }



    }
}
