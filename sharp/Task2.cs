namespace Task2
{
  abstract class Pizza
  {
    protected bool isBaked = false;
    protected bool isSliced = false;
    protected bool isEaten = false;

    public virtual string PizzaName { get; }
    protected int Diameter { get; set; }
    protected string Dough { get; set; }
    protected string Crust { get; set; }

    public Pizza(int diameter, string dough, string crust)
    {
      Diameter = diameter;
      Dough = dough;
      Crust = crust;
    }

    public Pizza(int diameter, int dough, int crust)
    {
      switch (diameter)
      {
        case 0:
          Diameter = 16;
          break;
        case 1:
          Diameter = 24;
          break;
        case 2:
          Diameter = 32;
          break;
        default:
          Diameter = 24;
          break;
      };

      switch (dough)
      {
        case 0:
          Dough = "тонкое";
          break;
        case 1:
          Dough = "стандартное";
          break;
        default:
          Dough = "тонкое";
          break;
      }

      switch (crust)
      {
        case 0:
          Crust = "стандартная";
          break;
        case 1:
          Crust = "сырная";
          break;
        default:
          Crust = "стандартная";
          break;
      }
    }

    public Pizza()
    {
      Diameter = 24;
      Dough = "стандартное";
      Crust = "стандартная";
    }

    public void Bake()
    {
      if (isBaked)
      {
        Console.WriteLine($"Пицца {PizzaName} уже приготовлена");
      }
      else
      {
        isBaked = true;
        Console.WriteLine($"Вы приготовили пиццу {PizzaName}");
      }
    }

    public void Slice()
    {
      if (!isBaked)
      {
        Console.WriteLine($"Пицца {PizzaName} еще не приготовлена");
        return;
      }
      else if (isSliced)
      {
        Console.WriteLine($"Пицца {PizzaName} уже нарезана");
      }
      else
      {
        isSliced = true;
        Console.WriteLine($"Вы нарезали пиццу {PizzaName}");
      }
    }

    public void Eat()
    {
      if (!isBaked)
      {
        Console.WriteLine($"Пицца {PizzaName} еще не приготовлена");
        return;
      }
      else if (!isSliced)
      {
        Console.WriteLine($"Пицца {PizzaName} еще не нарезана");
      }
      else if (isEaten)
      {
        Console.WriteLine($"Пицца {PizzaName} уже съедена");
      }
      else
      {
        isEaten = true;
        Console.WriteLine($"Вы съели пиццу {PizzaName}");
      }
    }

    public abstract override string ToString();

    public virtual string ClassName()
    {
      return "Class \"Pizza\"";
    }
  }

  class Margarita : Pizza
  {
    public override string PizzaName { get { return "Маргарита"; } }
    private bool ExtraCheese { get; set; }

    public Margarita(int diameter, string dough, string crust) : base(diameter, dough, crust)
    {
    }

    public Margarita(int diameter, int dough, int crust) : base(diameter, dough, crust)
    {
    }

    public Margarita() : base()
    {
    }

    public override string ToString()
    {
      return $"Пицца {PizzaName}.\nДиаметр: {Diameter}\nТесто: {Dough}\n" +
      $"Корка: {Crust}\nДополнительный сыр: {ExtraCheese}";
    }

    public void AddExtraCheese()
    {

      if (isBaked || isSliced || isEaten)
      {
        Console.WriteLine("\nСлишком поздно, пицца уже готова, а может быть и съедена\n");
      }
      else if (ExtraCheese)
      {
        Console.WriteLine("\nДополнительный сыр уже добавлен!\n");
      }
      else
      {
        ExtraCheese = true;
        Console.WriteLine("\nВы добавили дополнительный сыр\n");
      }
    }

    public override string ClassName()
    {
      return base.ClassName() + " -> Class \"Margarita\"";
    }
  }

  class Meat : Margarita
  {
    public override string PizzaName { get { return "Мясная"; } }
    protected int MeatAmount { get; set; }
    protected virtual int MaxMeat { get; set; } = 128;

    public Meat(int diameter, string dough, string crust, int meatAmount)
      : base(diameter, dough, crust)
    {
      MeatAmount = meatAmount;
    }

    public Meat(int diameter, int dough, int crust, int meatAmount)
      : base(diameter, dough, crust)
    {
      switch (meatAmount)
      {
        case 0:
          MeatAmount = 8;
          break;
        case 1:
          MeatAmount = 16;
          break;
        case 2:
          MeatAmount = 32;
          break;
        default:
          MeatAmount = 16;
          break;
      }
    }

    public Meat() : base()
    {
      MeatAmount = 16;
    }

    public void AddMoreMeat()
    {
      if (isBaked || isSliced || isEaten)
      {
        Console.WriteLine("\nСлишком поздно, пицца уже готова, а может быть и съедена\n");
      }
      else if (MeatAmount >= MaxMeat)
      {
        Console.WriteLine("\nСлишком много мяса! Больше добваить нельзя\n");
      }
      else
      {
        MeatAmount *= 2;
        Console.WriteLine("\nКоличество мяса удвоено!\n");
      }
    }

    public override string ToString()
    {
      return $"Пицца {PizzaName}.\nДиаметр: {Diameter}\nТесто: {Dough}\n" +
      $"Корка: {Crust}\nКоличество мяса: {MeatAmount}";
    }

    public override string ClassName()
    {
      return base.ClassName() + " -> Class \"Meat\"";
    }
  }

  class QuattroFormaggi : Pizza
  {
    public override string PizzaName { get { return "4 сыра"; } }
    private bool SouceIncluded { get; set; }

    public QuattroFormaggi(int diameter, string dough, string crust, bool souceIncluded)
      : base(diameter, dough, crust)
    {
      SouceIncluded = souceIncluded;
    }

    public QuattroFormaggi(int diameter, int dough, int crust, int souceIncluded)
      : base(diameter, dough, crust)
    {
      SouceIncluded = Convert.ToBoolean(souceIncluded);
    }

    public QuattroFormaggi() : base()
    {
      SouceIncluded = true;
    }

    public override string ToString()
    {
      return $"Пицца {PizzaName}.\nДиаметр: {Diameter}\nТесто: {Dough}\n" +
      $"Корка: {Crust}\nСоус: {SouceIncluded}";
    }

    public override string ClassName()
    {
      return base.ClassName() + " -> Class \"QuattroFormaggi\"";
    }

    public static bool operator ==(QuattroFormaggi a, QuattroFormaggi b)
    {
      return a.Diameter == b.Diameter &&
       a.Dough == b.Dough &&
        a.Crust == b.Crust &&
         a.SouceIncluded == b.SouceIncluded;
    }

    public static bool operator !=(QuattroFormaggi a, QuattroFormaggi b)
    {
      return a.Diameter != b.Diameter ||
       a.Dough != b.Dough ||
        a.Crust != b.Crust ||
         a.SouceIncluded != b.SouceIncluded;
    }

    public override bool Equals(object o)
    {
      return this == (QuattroFormaggi)o;
    }

    public override int GetHashCode()
    {
      throw new NotImplementedException();
    }

    public static QuattroFormaggi operator +(QuattroFormaggi a, QuattroFormaggi b)
    {
      int newDiameter = a.Diameter + b.Diameter;
      if (newDiameter > 32) newDiameter = 32;

      int doughA = a.Dough == "тонкое" ? 0 : 1;
      int doughB = b.Dough == "тонкое" ? 0 : 1;
      string newDough = Math.Max(doughA, doughB) == 0 ? "тонкое" : "стандартное";

      int crustA = a.Crust == "стандартная" ? 0 : 1;
      int crustB = b.Crust == "стандартная" ? 0 : 1;
      string newCrust = Math.Max(crustA, crustB) == 0 ? "стандартная" : "сырная";

      bool newSouce = a.SouceIncluded || b.SouceIncluded;

      return new QuattroFormaggi(newDiameter, newDough, newCrust, newSouce);
    }
  }

  sealed class Fungi : Pizza
  {
    public override string PizzaName { get { return "Прошутто Фунги"; } }
    protected int HamAmount { get; set; }


    public Fungi(int diameter, string dough, string crust, int hamAmount)
      : base(diameter, dough, crust)
    {
      HamAmount = hamAmount;
    }

    public Fungi(int diameter, int dough, int crust, int hamAmount)
      : base(diameter, dough, crust)
    {
      switch (hamAmount)
      {
        case 0:
          HamAmount = 4;
          break;
        case 1:
          HamAmount = 8;
          break;
        case 2:
          HamAmount = 16;
          break;
        default:
          HamAmount = 8;
          break;
      }
    }

    public Fungi() : base()
    {
      HamAmount = 8;
    }

    public void AddMoreHam()
    {
      if (isBaked || isSliced || isEaten)
      {
        Console.WriteLine("\nСлишком поздно, пицца уже готова, а может быть и съедена\n");
      }
      else
      {
        HamAmount += 4;
        Console.WriteLine("\nКоличество ветчины увеличено!\n");
      }
    }

    public override string ToString()
    {
      return $"Пицца {PizzaName}.\nДиаметр: {Diameter}\nТесто: {Dough}\n" +
      $"Корка: {Crust}\nКоличество ветчины: {HamAmount}";
    }

    public override string ClassName()
    {
      return base.ClassName() + " -> Class \"Fungi\"";
    }
  }

  internal class Runner
  {
    public static void Run()
    {
      List<Pizza> pizzas = new List<Pizza>();
      while (true)
      {
        Console.WriteLine("\nЧто будем делать?\n" +
        "0 - создать новую пиццу\n" +
        "1 - выбрать существующую пиццу\n");
        int menuAction = Convert.ToInt16(Console.ReadLine());

        switch (menuAction)
        {
          case 0:
            {
              Pizza pizza;

              Console.WriteLine("\nКакую пиццу готовим?\n" +
              "0 - Маргариту\n" +
              "1 - Мясную\n" +
              "2 - 4 сыра\n" +
              "3 - Прошутто Фунги\n");

              int pizzaType = Convert.ToInt16(Console.ReadLine());

              switch (pizzaType)
              {
                case 0:
                  {
                    Console.WriteLine("\nГотовим новую пиццу Маргариту!\n");
                    Console.WriteLine("\nВыберите конструктор:\n" +
                    "0 - если хотите выбрать параметры пиццы самостоятельно\n" +
                    "1 - если хотите выбрать стандартные параметры пиццы\n");

                    int constructor = Convert.ToInt16(Console.ReadLine());
                    switch (constructor)
                    {
                      case 0:
                        {
                          Console.WriteLine("\nВыберите диаметр пиццы:\n" +
                          "0 - 16см\n" +
                          "1 - 24см\n" +
                          "2 - 32см\n");
                          int diameter = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nВыберите тесто для пиццы:\n" +
                          "0 - тонкое\n" +
                          "1 - стандартное\n");
                          int dough = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nВыберите тип корочки для пиццы:\n" +
                          "0 - стандартная\n" +
                          "1 - сырная\n");
                          int crust = Convert.ToInt16(Console.ReadLine());

                          pizza = new Margarita(diameter, dough, crust);
                          break;
                        }
                      default:
                        {
                          pizza = new Margarita();
                          break;
                        }
                    }
                    break;
                  }
                case 1:
                  {
                    Console.WriteLine("\nГотовим новую пиццу Мясную!\n");
                    Console.WriteLine("\nВыберите конструктор:\n" +
                    "0 - если хотите выбрать параметры пиццы самостоятельно\n" +
                    "1 - если хотите выбрать стандартные параметры пиццы\n");

                    int constructor = Convert.ToInt16(Console.ReadLine());
                    switch (constructor)
                    {
                      case 0:
                        {
                          Console.WriteLine("\nВыберите диаметр пиццы:\n" +
                          "0 - 16см\n" +
                          "1 - 24см\n" +
                          "2 - 32см\n");
                          int diameter = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nВыберите тесто для пиццы:\n" +
                          "0 - тонкое\n" +
                          "1 - стандартное\n");
                          int dough = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nВыберите тип корочки для пиццы:\n" +
                          "0 - стандартная\n" +
                          "1 - сырная\n");
                          int crust = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nСколько мяса добавить?\n" +
                          "0 - мало\n" +
                          "1 - нормально\n" +
                          "2 - много\n");
                          int meatAmount = Convert.ToInt16(Console.ReadLine());

                          pizza = new Meat(diameter, dough, crust, meatAmount);
                          break;
                        }
                      default:
                        {
                          pizza = new Meat();
                          break;
                        }
                    }
                    break;
                  }
                case 2:
                  {
                    Console.WriteLine($"\nГотовим новую пиццу 4 сыра!\n");
                    Console.WriteLine("\nВыберите конструктор:\n" +
                    "0 - если хотите выбрать параметры пиццы самостоятельно\n" +
                    "1 - если хотите выбрать стандартные параметры пиццы\n");

                    int constructor = Convert.ToInt16(Console.ReadLine());
                    switch (constructor)
                    {
                      case 0:
                        {
                          Console.WriteLine("\nВыберите диаметр пиццы:\n" +
                          "0 - 16см\n" +
                          "1 - 24см\n" +
                          "2 - 32см\n");
                          int diameter = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nВыберите тесто для пиццы:\n" +
                          "0 - тонкое\n" +
                          "1 - стандартное\n");
                          int dough = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nВыберите тип корочки для пиццы:\n" +
                          "0 - стандартная\n" +
                          "1 - сырная\n");
                          int crust = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nДобавить соус для пиццы?\n" +
                          "0 - нет\n" +
                          "1 - да\n");
                          int souce = Convert.ToInt16(Console.ReadLine());

                          pizza = new QuattroFormaggi(diameter, dough, crust, souce);
                          break;
                        }
                      default:
                        {
                          pizza = new QuattroFormaggi();
                          break;
                        }
                    }

                    break;
                  }
                case 3:
                  {
                    Console.WriteLine("\nГотовим новую пиццу Прошутто Фунги!\n");
                    Console.WriteLine("\nВыберите конструктор:\n" +
                    "0 - если хотите выбрать параметры пиццы самостоятельно\n" +
                    "1 - если хотите выбрать стандартные параметры пиццы\n");

                    int constructor = Convert.ToInt16(Console.ReadLine());
                    switch (constructor)
                    {
                      case 0:
                        {
                          Console.WriteLine("\nВыберите диаметр пиццы:\n" +
                          "0 - 16см\n" +
                          "1 - 24см\n" +
                          "2 - 32см\n");
                          int diameter = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nВыберите тесто для пиццы:\n" +
                          "0 - тонкое\n" +
                          "1 - стандартное\n");
                          int dough = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nВыберите тип корочки для пиццы:\n" +
                          "0 - стандартная\n" +
                          "1 - сырная\n");
                          int crust = Convert.ToInt16(Console.ReadLine());

                          Console.WriteLine("\nСколько ветчины добавить?\n" +
                          "0 - мало\n" +
                          "1 - нормально\n" +
                          "2 - много\n");
                          int hamAmount = Convert.ToInt16(Console.ReadLine());

                          pizza = new Fungi(diameter, dough, crust, hamAmount);
                          break;
                        }
                      default:
                        {
                          pizza = new Fungi();
                          break;
                        }
                    }
                    break;
                  }
                default:
                  pizza = new Margarita();
                  break;
              }

              Console.WriteLine($"\nСоздана пицца:\n{pizza}\n{pizza.ClassName()}");
              pizzas.Add(pizza);
              break;
            }
          case 1:
            {
              if (pizzas.Count == 0)
              {
                Console.WriteLine("\nПока не создано ни одной пиццы\n");
              }
              else
              {
                Console.WriteLine($"\nВсего создано {pizzas.Count} пицц\n" +
                $"Введите индекс (от 0 до {pizzas.Count - 1}) чтобы выбрать пиццу\n");
                int pizzaIndex = Convert.ToInt16(Console.ReadLine());
                Pizza pizza = pizzas[pizzaIndex];

                int pizzaAction;
                if (pizza.GetType() == typeof(Margarita))
                {
                  Margarita margaritaPizza = (Margarita)pizza;
                  do
                  {
                    Console.WriteLine("\nДоступные действия:\n" +
                    "0 - приготовить пиццу\n" +
                    "1 - нарезать пиццу\n" +
                    "2 - съесть пиццу\n" +
                    "3 - добавить больше сыра\n" +
                    "4 - показать параметры пиццы\n" +
                    "5 - в главное меню\n");

                    pizzaAction = Convert.ToInt16(Console.ReadLine());

                    switch (pizzaAction)
                    {
                      case 0:
                        margaritaPizza.Bake();
                        break;
                      case 1:
                        margaritaPizza.Slice();
                        break;
                      case 2:
                        margaritaPizza.Eat();
                        break;
                      case 3:
                        margaritaPizza.AddExtraCheese();
                        break;
                      case 4:
                        Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
                        break;
                    }
                  } while (pizzaAction != 5);
                }
                else if (pizza.GetType() == typeof(QuattroFormaggi))
                {
                  QuattroFormaggi formagiPizza = (QuattroFormaggi)pizza;
                  do
                  {
                    Console.WriteLine("\nДоступные действия:\n" +
                    "0 - приготовить пиццу\n" +
                    "1 - нарезать пиццу\n" +
                    "2 - съесть пиццу\n" +
                    "3 - показать параметры пиццы\n" +
                    "4 - в главное меню\n");

                    pizzaAction = Convert.ToInt16(Console.ReadLine());

                    switch (pizzaAction)
                    {
                      case 0:
                        formagiPizza.Bake();
                        break;
                      case 1:
                        formagiPizza.Slice();
                        break;
                      case 2:
                        formagiPizza.Eat();
                        break;
                      case 3:
                        Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
                        break;
                    }
                  } while (pizzaAction != 4);
                }
                else if (pizza.GetType() == typeof(Fungi))
                {
                  Fungi fungiPizza = (Fungi)pizza;
                  do
                  {
                    Console.WriteLine("\nДоступные действия:\n" +
                    "0 - приготовить пиццу\n" +
                    "1 - нарезать пиццу\n" +
                    "2 - съесть пиццу\n" +
                    "3 - добавить больше ветчины\n" +
                    "4 - показать параметры пиццы\n" +
                    "5 - в главное меню\n");

                    pizzaAction = Convert.ToInt16(Console.ReadLine());

                    switch (pizzaAction)
                    {
                      case 0:
                        fungiPizza.Bake();
                        break;
                      case 1:
                        fungiPizza.Slice();
                        break;
                      case 2:
                        fungiPizza.Eat();
                        break;
                      case 3:
                        fungiPizza.AddMoreHam();
                        break;
                      case 4:
                        Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
                        break;
                    }
                  } while (pizzaAction != 5);
                }
                else if (pizza.GetType() == typeof(Meat))
                {
                  Meat meatPizza = (Meat)pizza;
                  do
                  {
                    Console.WriteLine("\nДоступные действия:\n" +
                    "0 - приготовить пиццу\n" +
                    "1 - нарезать пиццу\n" +
                    "2 - съесть пиццу\n" +
                    "3 - добавить больше сыра\n" +
                    "4 - добавить больше мяса\n" +
                    "5 - показать параметры пиццы\n" +
                    "6 - в главное меню\n");

                    pizzaAction = Convert.ToInt16(Console.ReadLine());

                    switch (pizzaAction)
                    {
                      case 0:
                        meatPizza.Bake();
                        break;
                      case 1:
                        meatPizza.Slice();
                        break;
                      case 2:
                        meatPizza.Eat();
                        break;
                      case 3:
                        meatPizza.AddExtraCheese();
                        break;
                      case 4:
                        meatPizza.AddMoreMeat();
                        break;
                      case 5:
                        Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
                        break;
                    }
                  } while (pizzaAction != 6);
                }
              }
              break;
            }
        }
      }
    }
  }
}
