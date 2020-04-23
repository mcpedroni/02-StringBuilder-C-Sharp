using System;

namespace Orders.Entities {

    class Client {

        public string name { get; set; }
        public string email { get; set; }
        public DateTime birthDate { get; set; }

        public Client() { }

        public Client(string name, string email, DateTime birthDate) {
            this.name = name;
            this.email = email;
            this.birthDate = birthDate;
        }

        public override string ToString() {
            return  name + " (" + birthDate.ToString("dd/MM/yyyy") + ") " + " - " + email; 
        }
    }
}
