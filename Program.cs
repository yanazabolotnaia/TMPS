using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new ClientBuilder()
                .Name("Alexei")
                .Surname("Pozornic")
                .Address("Studentilor 1/1")
                .Build();
            

            Delivery delivery = new LinellaDelivery("Линелла");
            DeliveryMarket market = delivery.Create();
            Delivery delivery1 = new Nr1Delivery("Номер Один");
            DeliveryMarket market2 = delivery1.Create();

            //prototype
            Delivery delivery3 =  delivery.GetClone();
            delivery3.MarketName = "Фуршет";
            Console.WriteLine(delivery3.MarketName 
                               + "\nДоставка из магазина " 
                               + delivery3.MarketName 
                               + " для клиента {0} {1} {2}", client1.Name, client1.Surname,client1.Address);

          
        }
    }

    abstract class Delivery
    {
       
        public string MarketName { get; set; }
        


        public Delivery(string n)
        {
            MarketName = n;
            

        }
        public Delivery GetClone()
        {
            return (Delivery)this.MemberwiseClone();
        }
        // фабричный метод
        abstract public DeliveryMarket Create();
    }
    
    class LinellaDelivery : Delivery
    {
        public LinellaDelivery(string n) : base(n)
        {
            Console.WriteLine(this.MarketName);
        }

        public override DeliveryMarket Create()
        {
            return new DeliveryFromLinella();
        }
    }
   
    class Nr1Delivery : Delivery
    {
        public Nr1Delivery(string n) : base(n)
        {
            Console.WriteLine( this.MarketName);
        }

        public override DeliveryMarket Create()
        {
            return new DeliveryFromN1();
        }
    }

    abstract class DeliveryMarket
    {
        
    }

    class DeliveryFromLinella : DeliveryMarket
    {
        public DeliveryFromLinella()
        {
            Console.WriteLine("Доставочка из Линеллы клиенту\n");
        }
    }
    class DeliveryFromN1 : DeliveryMarket
    {
        public DeliveryFromN1()
        {
            Console.WriteLine("Доставочка из магазина Номер один\n");
        }
    }

    //builder
    public class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }

    public class ClientBuilder
    {
        private readonly Client _client;

        public ClientBuilder()
        {
            _client = new Client();
        }

        public ClientBuilder Name(string name)
        {
            _client.Name = name;
            return this;
        }

        public ClientBuilder Surname(string surname)
        {
            _client.Surname = surname;
            return this;
        }

        public ClientBuilder Address(string address)
        {
            _client.Address = address;
            return this;
        }


        public Client Build()
        {

            return _client;
        }
    }
}
