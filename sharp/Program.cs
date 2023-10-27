class QuattroFormaggi
{
  private const string pizzaName = "4 сыра";
  private bool isBaked = false;
  private bool isSliced = false;
  private bool isEaten = false;

  private int Diameter { get; set; }
  private string Dough { get; set; }
  private string Crust { get; set; }
  private bool SouceIncluded { get; set; }

  public QuattroFormaggi(int diameter, string dough, string crust, bool souceIncluded)
  {
    Diameter = diameter;
    Dough = dough;
    Crust = crust;
    SouceIncluded = souceIncluded;
  }

  public QuattroFormaggi(int diameter, int dough, int crust, int souceIncluded)
  {
    Diameter = diameter switch
    {
      0 => 16,
      1 => 24,
      2 => 32,
      _ => 24,
    };
    Dough = dough switch
    {
      0 => "тонкое",
      1 => "стандартное",
      _ => "стандартное",
    };
    Crust = crust switch
    {
      0 => "стандартная",
      1 => "сырная",
      _ => "стандартная",
    };
    SouceIncluded = Convert.ToBoolean(souceIncluded);
  }

  public QuattroFormaggi()
  {
    Diameter = 24;
    Dough = "стандартное";
    Crust = "стандартная";
    SouceIncluded = true;
  }

  public void Bake()
  {
    if (isBaked)
    {
      Console.WriteLine($"Пицца {pizzaName} уже приготовлена");
    }
    else
    {
      isBaked = true;
      Console.WriteLine($"Вы приготовили пиццу {pizzaName}");
    }
  }

  public void Slice()
  {
    if (!isBaked)
    {
      Console.WriteLine($"Пицца {pizzaName} еще не приготовлена");
      return;
    }
    else if (isSliced)
    {
      Console.WriteLine($"Пицца {pizzaName} уже нарезана");
    }
    else
    {
      isSliced = true;
      Console.WriteLine($"Вы нарезали пиццу {pizzaName}");
    }
  }

  public void Eat()
  {
    if (!isBaked)
    {
      Console.WriteLine($"Пицца {pizzaName} еще не приготовлена");
      return;
    }
    else if (!isSliced)
    {
      Console.WriteLine($"Пицца {pizzaName} еще не нарезана");
    }
    else if (isEaten)
    {
      Console.WriteLine($"Пицца {pizzaName} уже съедена");
    }
    else
    {
      isEaten = true;
      Console.WriteLine($"Вы съели пиццу ${pizzaName}");
    }
  }

  public override string ToString()
  {
    return $"Пицца {pizzaName}.\nДиаметр: {Diameter}\nТесто: {Dough}\n" +
    $"Корка: {Crust}\nСоус: {SouceIncluded}";
  }

  public static string GetDescription()
  {
    return $"Пицца {pizzaName}\nИнгридиенты: моцарелла, эмменталь, горгонзола, пармезан, орегано";
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

class Program
{
  static void Main()
  {
    List<QuattroFormaggi> pizzas = new List<QuattroFormaggi>();
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
            QuattroFormaggi pizza;
            Console.WriteLine($"\nГотовим новую пиццу!\n{QuattroFormaggi.GetDescription()}\n");
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
              case 1:
                {
                  pizza = new QuattroFormaggi();
                  break;
                }
              default:
                {
                  pizza = new QuattroFormaggi();
                  break;
                }
            }
            Console.WriteLine($"\nСоздана пицца:\n{pizza}");
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
              QuattroFormaggi pizza = pizzas[pizzaIndex];

              Console.WriteLine($"\nПараметры пиццы:\n{pizza}");
              int pizzaAction;
              do
              {
                Console.WriteLine("\nДоступные действия:\n" +
                "0 - приготовить пиццу\n" +
                "1 - нарезать пиццу\n" +
                "2 - съесть пиццу\n" +
                "3 - сравнить пиццу с другой\n" +
                "4 - добавить к текущей пицце другую!\n" +
                "5 - в главное меню\n");

                pizzaAction = Convert.ToInt16(Console.ReadLine());

                switch (pizzaAction)
                {
                  case 0:
                    pizza.Bake();
                    break;
                  case 1:
                    pizza.Slice();
                    break;
                  case 2:
                    pizza.Eat();
                    break;
                  case 3:
                    {
                      Console.WriteLine("\nВыберите пиццу с которой хотите сравнить текущую\n" +
                      $"Введите индекс (от 0 до {pizzas.Count - 1}) чтобы выбрать пиццу\n");
                      int pizza2Index = Convert.ToInt16(Console.ReadLine());
                      QuattroFormaggi pizza2 = pizzas[pizza2Index];

                      if (pizza == pizza2)
                      {
                        Console.WriteLine("Пиццы равны!");
                      }
                      else
                      {
                        Console.WriteLine("Пиццы не равны!");
                      }
                      break;
                    }
                  case 4:
                    {
                      Console.WriteLine("\nВыберите пиццу которую хотите сложить текущую\n" +
                      $"Введите индекс (от 0 до {pizzas.Count - 1}) чтобы выбрать пиццу\n");
                      int pizza2Index = Convert.ToInt16(Console.ReadLine());
                      QuattroFormaggi pizza2 = pizzas[pizza2Index];

                      QuattroFormaggi resultPizza = pizza + pizza2;
                      Console.WriteLine($"\nВот такая пицца получилась в результате сложения {resultPizza}\n");
                      break;
                    }
                }
              } while (pizzaAction != 5);
            }
            break;
          }
      }
    }
  }
}
