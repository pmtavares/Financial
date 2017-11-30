using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Client
    {
        private long idClient;
        private string name;
        private string pps;
        private string address;
        private string phone;
        private int status; //not get and set for status because it is not in DB

        

        [Display(Name = "Client code")]
        public long IdClient { get => idClient; set => idClient = value; }

        [Display(Name = "Name")]
        [Required(ErrorMessage ="This field is required")]
        public string Name { get => name; set => name = value; }

        [Display(Name = "PPS")]
        public string Pps { get => pps; set => pps = value; }

        [Display(Name = "Address")]
        public string Address { get => address; set => address = value; }

        [Display(Name = "Phone")]
        public string Phone { get => phone; set => phone = value; }

        public int Status { get => status; set => status = value; }

        public Client()
        {

        }
        public Client(long id)
        {
            this.idClient = id;
        }

        public Client(long id, string name, string pps, string addres, string phone)
        {
            this.idClient = id;
            this.Name = name;
            this.Pps = pps;
            this.Address = addres;
            this.Phone = phone;

        }
    }
}
