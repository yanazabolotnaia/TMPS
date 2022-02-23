using SinglAbstr;
using System;

namespace SinglAbstr
{
  
    public interface AbstractFactory
    {
        public abstract IAbstractProductA CreateUserA();

        private static AbstractFactory instance = null;
        
        //function to access the single instance object
        public static AbstractFactory Instance()
        {
            if (instance == null)
            {
                instance = getInstance();
            }
            return instance;
        }
      
        public static AbstractFactory getInstance()
        {
            Console.WriteLine("Введите цифру");
            Console.WriteLine("1 - Admin\n2 - StakeHolder\n3 - ProjectManager ");
            int userType = Int32.Parse(Console.ReadLine());
            

            switch (userType)
            {
                case 1:
                    return new ConcreteFactory1();
                case 2:
                    return new ConcreteFactory2();
                case 3:
                    return new ConcreteFactory3();
                default:return null;
            }
            
        }
        
    }

    class ConcreteFactory1 : AbstractFactory
    {
       

        public IAbstractProductA CreateUserA()
        {
            return new ConcreteUserA1();
        }


    }

    class ConcreteFactory2 : AbstractFactory
    {
        public IAbstractProductA CreateUserA()
        {
            return new ConcreteUserA2();
        }

    }
    class ConcreteFactory3 : AbstractFactory
    {
        public  IAbstractProductA CreateUserA()
        {
            return new ConcreteUserA3();
        }

    }

    public interface IAbstractProductA
    {
        string UsefulFunctionA();
        
    }


    class ConcreteUserA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "Это страница админа";
        }
    }

    class ConcreteUserA2 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "Это страница стэйк-холдера.";
        }
    }

    class ConcreteUserA3 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "Это страница прожект-менеджера";
        }
    }


    class User
    {
        public void Main()
        {
            AbstractFactory factory = AbstractFactory.Instance();
            IAbstractProductA dc = factory.CreateUserA();
            Console.WriteLine(dc.UsefulFunctionA());
            

        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            new User().Main();
            

        }
    }
}

