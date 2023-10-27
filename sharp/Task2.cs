// namespace Task2
// {
//   abstract class Pizza
//   {
//     protected bool isBaked = false;
//     protected bool isSliced = false;
//     protected bool isEaten = false;

//     public virtual string PizzaName { get; }
//     protected int Diameter { get; set; }
//     protected string Dough { get; set; }
//     protected string Crust { get; set; }

//     public Pizza(int diameter, string dough, string crust)
//     {
//       Diameter = diameter;
//       Dough = dough;
//       Crust = crust;
//     }

//     public Pizza(int diameter, int dough, int crust)
//     {
//       switch (diameter)
//       {
//         case 0:
//           Diameter = 16;
//           break;
//         case 1:
//           Diameter = 24;
//           break;
//         case 2:
//           Diameter = 32;
//           break;
//         default:
//           Diameter = 24;
//           break;
//       };

//       switch (dough)
//       {
//         case 0:
//           Dough = "тонкое";
//           break;
//         case 1:
//           Dough = "стандартное";
//           break;
//         default:
//           Dough = "тонкое";
//           break;
//       }

//       switch (crust)
//       {
//         case 0:
//           Crust = "стандартная";
//           break;
//         case 1:
//           Crust = "сырная";
//           break;
//         default:
//           Crust = "стандартная";
//           break;
//       }
//     }

//     public Pizza()
//     {
//       Diameter = 24;
//       Dough = "стандартное";
//       Crust = "стандартная";
//     }

//     public void Bake()
//     {
//       if (isBaked)
//       {
//         Console.WriteLine($"Пицца {PizzaName} уже приготовлена");
//       }
//       else
//       {
//         isBaked = true;
//         Console.WriteLine($"Вы приготовили пиццу {PizzaName}");
//       }
//     }

//     public void Slice()
//     {
//       if (!isBaked)
//       {
//         Console.WriteLine($"Пицца {PizzaName} еще не приготовлена");
//         return;
//       }
//       else if (isSliced)
//       {
//         Console.WriteLine($"Пицца {PizzaName} уже нарезана");
//       }
//       else
//       {
//         isSliced = true;
//         Console.WriteLine($"Вы нарезали пиццу {PizzaName}");
//       }
//     }

//     public void Eat()
//     {
//       if (!isBaked)
//       {
//         Console.WriteLine($"Пицца {PizzaName} еще не приготовлена");
//         return;
//       }
//       else if (!isSliced)
//       {
//         Console.WriteLine($"Пицца {PizzaName} еще не нарезана");
//       }
//       else if (isEaten)
//       {
//         Console.WriteLine($"Пицца {PizzaName} уже съедена");
//       }
//       else
//       {
//         isEaten = true;
//         Console.WriteLine($"Вы съели пиццу ${PizzaName}");
//       }
//     }

//     public abstract override string ToString();

//     public virtual string ClassName()
//     {
//       return "Class \"Pizza\"";
//     }
//   }

//   sealed class Hawaii : Pizza
//   {
//     public override string PizzaName { get { return "Гавайская"; } }
//     private const bool AnanasIncluded = true;

//     public Hawaii(int diameter, string dough, string crust) : base(diameter, dough, crust)
//     {
//     }

//     public Hawaii(int diameter, int dough, int crust) : base(diameter, dough, crust)
//     {
//     }

//     public Hawaii() : base()
//     {
//     }

//     public override string ToString()
//     {
//       return $"Пицца {PizzaName}.\nДиаметр: {Diameter}\nТесто: {Dough}\n" +
//       $"Корка: {Crust}\nАнанасы: {AnanasIncluded}";
//     }

//     public void RemoveAnanas()
//     {
//       Console.WriteLine("\nЭто Гавайская пицца, смирись\n");
//     }

//     public override string ClassName()
//     {
//       return base.ClassName() + " -> Class \"Hawaii\"";
//     }
//   }

//   class QuattroFormaggi : Pizza
//   {
//     public override string PizzaName { get { return "4 сыра"; } }
//     private bool SouceIncluded { get; set; }

//     public QuattroFormaggi(int diameter, string dough, string crust, bool souceIncluded)
//       : base(diameter, dough, crust)
//     {
//       SouceIncluded = souceIncluded;
//     }

//     public QuattroFormaggi(int diameter, int dough, int crust, int souceIncluded)
//       : base(diameter, dough, crust)
//     {
//       SouceIncluded = Convert.ToBoolean(souceIncluded);
//     }

//     public QuattroFormaggi() : base()
//     {
//       SouceIncluded = true;
//     }

//     public override string ToString()
//     {
//       return $"Пицца {PizzaName}.\nДиаметр: {Diameter}\nТесто: {Dough}\n" +
//       $"Корка: {Crust}\nСоус: {SouceIncluded}";
//     }

//     public override string ClassName()
//     {
//       return base.ClassName() + " -> Class \"QuattroFormaggi\"";
//     }

//     public static bool operator ==(QuattroFormaggi a, QuattroFormaggi b)
//     {
//       return a.Diameter == b.Diameter &&
//        a.Dough == b.Dough &&
//         a.Crust == b.Crust &&
//          a.SouceIncluded == b.SouceIncluded;
//     }

//     public static bool operator !=(QuattroFormaggi a, QuattroFormaggi b)
//     {
//       return a.Diameter != b.Diameter ||
//        a.Dough != b.Dough ||
//         a.Crust != b.Crust ||
//          a.SouceIncluded != b.SouceIncluded;
//     }

//     public override bool Equals(object o)
//     {
//       return this == (QuattroFormaggi)o;
//     }

//     public override int GetHashCode()
//     {
//       throw new NotImplementedException();
//     }

//     public static QuattroFormaggi operator +(QuattroFormaggi a, QuattroFormaggi b)
//     {
//       int newDiameter = a.Diameter + b.Diameter;
//       if (newDiameter > 32) newDiameter = 32;

//       int doughA = a.Dough == "тонкое" ? 0 : 1;
//       int doughB = b.Dough == "тонкое" ? 0 : 1;
//       string newDough = Math.Max(doughA, doughB) == 0 ? "тонкое" : "стандартное";

//       int crustA = a.Crust == "стандартная" ? 0 : 1;
//       int crustB = b.Crust == "стандартная" ? 0 : 1;
//       string newCrust = Math.Max(crustA, crustB) == 0 ? "стандартная" : "сырная";

//       bool newSouce = a.SouceIncluded || b.SouceIncluded;

//       return new QuattroFormaggi(newDiameter, newDough, newCrust, newSouce);
//     }
//   }

//   class Pepperoni : Pizza
//   {
//     public override string PizzaName { get { return "Пепперони"; } }
//     protected int PepperoniAmount { get; set; }
//     protected virtual int MaxPepperoni { get; set; } = 128;

//     public Pepperoni(int diameter, string dough, string crust, int pepperoniAmount)
//       : base(diameter, dough, crust)
//     {
//       PepperoniAmount = pepperoniAmount;
//     }

//     public Pepperoni(int diameter, int dough, int crust, int pepperoniAmount)
//       : base(diameter, dough, crust)
//     {
//       switch (pepperoniAmount)
//       {
//         case 0:
//           PepperoniAmount = 8;
//           break;
//         case 1:
//           PepperoniAmount = 16;
//           break;
//         case 2:
//           PepperoniAmount = 32;
//           break;
//         default:
//           PepperoniAmount = 16;
//           break;
//       }
//     }

//     public Pepperoni() : base()
//     {
//       PepperoniAmount = 16;
//     }

//     public void AddMorePepperoni()
//     {
//       if (isBaked || isSliced || isEaten)
//       {
//         Console.WriteLine("\nСлишком поздно, пицца уже готова, а может быть и съедена\n");
//       }
//       else if (PepperoniAmount >= MaxPepperoni)
//       {
//         Console.WriteLine("\nСлишком много пепперони! Больше добваить нельзя\n");
//       }
//       else
//       {
//         PepperoniAmount *= 2;
//         Console.WriteLine("\nКоличество пепперони удвоено!\n");
//       }
//     }

//     public override string ToString()
//     {
//       return $"Пицца {PizzaName}.\nДиаметр: {Diameter}\nТесто: {Dough}\n" +
//       $"Корка: {Crust}\nКусков пепперони: {PepperoniAmount}";
//     }

//     public override string ClassName()
//     {
//       return base.ClassName() + " -> Class \"Pepperoni\"";
//     }
//   }

//   class JumboPepperoni : Pepperoni
//   {
//     public override string PizzaName { get { return "Большая пепперони"; } }
//     private bool MushroomsIncluded { get; set; }

//     public JumboPepperoni(string dough, string crust, int pepperoniAmount)
//       : base(48, dough, crust, pepperoniAmount * 2)
//     {
//       Diameter = 48;
//       MushroomsIncluded = false;
//     }

//     public JumboPepperoni(int dough, int crust, int pepperoniAmount)
//       : base(48, dough, crust, pepperoniAmount)
//     {
//       Diameter = 48;
//       PepperoniAmount *= 2;
//       MushroomsIncluded = false;
//     }

//     public JumboPepperoni() : base()
//     {
//       Diameter = 48;
//       PepperoniAmount *= 2;
//       MushroomsIncluded = false;
//     }
//     public void IncreaseDiameter()
//     {
//       Diameter *= 2;
//       MaxPepperoni *= 2;
//       Console.WriteLine("\nУвеличен диаметр пиццы!\n");
//     }

//     public void AddMushrooms()
//     {
//       if (MushroomsIncluded)
//       {
//         Console.WriteLine("\nВы уже добваили грибы\n");
//       }
//       else
//       {
//         MushroomsIncluded = true;
//         Console.WriteLine("\nГрибы добавлены\n");
//       }
//     }

//     public override string ClassName()
//     {
//       return base.ClassName() + " -> Class \"JumboPepperoni\"";
//     }
//   }

//   class Program
//   {
//     public static void Main()
//     {
//       List<Pizza> pizzas = new List<Pizza>();
//       while (true)
//       {
//         Console.WriteLine("\nЧто будем делать?\n" +
//         "0 - создать новую пиццу\n" +
//         "1 - выбрать существующую пиццу\n");
//         int menuAction = Convert.ToInt16(Console.ReadLine());

//         switch (menuAction)
//         {
//           case 0:
//             {
//               Pizza pizza;

//               Console.WriteLine("\nКакую пиццу готовим?\n" +
//               "0 - Гавайскую\n" +
//               "1 - 4 сыра\n" +
//               "2 - Пепперони\n" +
//               "3 - Огромную пепперони\n");

//               int pizzaType = Convert.ToInt16(Console.ReadLine());

//               switch (pizzaType)
//               {
//                 case 0:
//                   {
//                     Console.WriteLine($"\nГотовим новую пиццу Гавайскую!\n");
//                     Console.WriteLine("\nВыберите конструктор:\n" +
//                     "0 - если хотите выбрать параметры пиццы самостоятельно\n" +
//                     "1 - если хотите выбрать стандартные параметры пиццы\n");

//                     int constructor = Convert.ToInt16(Console.ReadLine());
//                     switch (constructor)
//                     {
//                       case 0:
//                         {
//                           Console.WriteLine("\nВыберите диаметр пиццы:\n" +
//                           "0 - 16см\n" +
//                           "1 - 24см\n" +
//                           "2 - 32см\n");
//                           int diameter = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nВыберите тесто для пиццы:\n" +
//                           "0 - тонкое\n" +
//                           "1 - стандартное\n");
//                           int dough = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nВыберите тип корочки для пиццы:\n" +
//                           "0 - стандартная\n" +
//                           "1 - сырная\n");
//                           int crust = Convert.ToInt16(Console.ReadLine());

//                           pizza = new Hawaii(diameter, dough, crust);
//                           break;
//                         }
//                       default:
//                         {
//                           pizza = new Hawaii();
//                           break;
//                         }
//                     }
//                     break;
//                   }
//                 case 1:
//                   {
//                     Console.WriteLine($"\nГотовим новую пиццу 4 сыра!\n");
//                     Console.WriteLine("\nВыберите конструктор:\n" +
//                     "0 - если хотите выбрать параметры пиццы самостоятельно\n" +
//                     "1 - если хотите выбрать стандартные параметры пиццы\n");

//                     int constructor = Convert.ToInt16(Console.ReadLine());
//                     switch (constructor)
//                     {
//                       case 0:
//                         {
//                           Console.WriteLine("\nВыберите диаметр пиццы:\n" +
//                           "0 - 16см\n" +
//                           "1 - 24см\n" +
//                           "2 - 32см\n");
//                           int diameter = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nВыберите тесто для пиццы:\n" +
//                           "0 - тонкое\n" +
//                           "1 - стандартное\n");
//                           int dough = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nВыберите тип корочки для пиццы:\n" +
//                           "0 - стандартная\n" +
//                           "1 - сырная\n");
//                           int crust = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nДобавить соус для пиццы?\n" +
//                           "0 - нет\n" +
//                           "1 - да\n");
//                           int souce = Convert.ToInt16(Console.ReadLine());

//                           pizza = new QuattroFormaggi(diameter, dough, crust, souce);
//                           break;
//                         }
//                       default:
//                         {
//                           pizza = new QuattroFormaggi();
//                           break;
//                         }
//                     }
//                     break;
//                   }
//                 case 2:
//                   {
//                     Console.WriteLine($"\nГотовим новую пиццу пепперони!\n");
//                     Console.WriteLine("\nВыберите конструктор:\n" +
//                     "0 - если хотите выбрать параметры пиццы самостоятельно\n" +
//                     "1 - если хотите выбрать стандартные параметры пиццы\n");

//                     int constructor = Convert.ToInt16(Console.ReadLine());
//                     switch (constructor)
//                     {
//                       case 0:
//                         {
//                           Console.WriteLine("\nВыберите диаметр пиццы:\n" +
//                           "0 - 16см\n" +
//                           "1 - 24см\n" +
//                           "2 - 32см\n");
//                           int diameter = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nВыберите тесто для пиццы:\n" +
//                           "0 - тонкое\n" +
//                           "1 - стандартное\n");
//                           int dough = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nВыберите тип корочки для пиццы:\n" +
//                           "0 - стандартная\n" +
//                           "1 - сырная\n");
//                           int crust = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nСколько пепперони добавить?\n" +
//                           "0 - мало\n" +
//                           "1 - нормально\n" +
//                           "2 - много\n");
//                           int pepperoniAmount = Convert.ToInt16(Console.ReadLine());

//                           pizza = new Pepperoni(diameter, dough, crust, pepperoniAmount);
//                           break;
//                         }
//                       default:
//                         {
//                           pizza = new Pepperoni();
//                           break;
//                         }
//                     }
//                     break;
//                   }
//                 case 3:
//                   {
//                     Console.WriteLine($"\nГотовим новую пиццу БОЛЬШУЮ пепперони!\n");
//                     Console.WriteLine("\nВыберите конструктор:\n" +
//                     "0 - если хотите выбрать параметры пиццы самостоятельно\n" +
//                     "1 - если хотите выбрать стандартные параметры пиццы\n");

//                     int constructor = Convert.ToInt16(Console.ReadLine());
//                     switch (constructor)
//                     {
//                       case 0:
//                         {
//                           Console.WriteLine("\nВыберите тесто для пиццы:\n" +
//                           "0 - тонкое\n" +
//                           "1 - стандартное\n");
//                           int dough = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nВыберите тип корочки для пиццы:\n" +
//                           "0 - стандартная\n" +
//                           "1 - сырная\n");
//                           int crust = Convert.ToInt16(Console.ReadLine());

//                           Console.WriteLine("\nСколько пепперони добавить?\n" +
//                           "0 - мало\n" +
//                           "1 - нормально\n" +
//                           "2 - много\n");
//                           int pepperoniAmount = Convert.ToInt16(Console.ReadLine());

//                           pizza = new JumboPepperoni(dough, crust, pepperoniAmount);
//                           break;
//                         }
//                       default:
//                         {
//                           pizza = new JumboPepperoni();
//                           break;
//                         }
//                     }
//                     break;
//                   }
//                 default:
//                   pizza = new Hawaii();
//                   break;
//               }

//               Console.WriteLine($"\nСоздана пицца:\n{pizza}\n{pizza.ClassName()}");
//               pizzas.Add(pizza);
//               break;
//             }
//           case 1:
//             {
//               if (pizzas.Count == 0)
//               {
//                 Console.WriteLine("\nПока не создано ни одной пиццы\n");
//               }
//               else
//               {
//                 Console.WriteLine($"\nВсего создано {pizzas.Count} пицц\n" +
//                 $"Введите индекс (от 0 до {pizzas.Count - 1}) чтобы выбрать пиццу\n");
//                 int pizzaIndex = Convert.ToInt16(Console.ReadLine());
//                 Pizza pizza = pizzas[pizzaIndex];

//                 int pizzaAction;
//                 if (pizza.GetType() == typeof(Hawaii))
//                 {
//                   Hawaii hawaiiPizza = (Hawaii)pizza;
//                   do
//                   {
//                     Console.WriteLine("\nДоступные действия:\n" +
//                     "0 - приготовить пиццу\n" +
//                     "1 - нарезать пиццу\n" +
//                     "2 - съесть пиццу\n" +
//                     "3 - убрать ананасы\n" +
//                     "4 - показать параметры пиццы\n" +
//                     "5 - в главное меню\n");

//                     pizzaAction = Convert.ToInt16(Console.ReadLine());

//                     switch (pizzaAction)
//                     {
//                       case 0:
//                         hawaiiPizza.Bake();
//                         break;
//                       case 1:
//                         hawaiiPizza.Slice();
//                         break;
//                       case 2:
//                         hawaiiPizza.Eat();
//                         break;
//                       case 3:
//                         hawaiiPizza.RemoveAnanas();
//                         break;
//                       case 4:
//                         Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
//                         break;
//                     }
//                   } while (pizzaAction != 5);
//                 }
//                 else if (pizza.GetType() == typeof(QuattroFormaggi))
//                 {
//                   QuattroFormaggi formagiPizza = (QuattroFormaggi)pizza;
//                   do
//                   {
//                     Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
//                     Console.WriteLine("\nДоступные действия:\n" +
//                     "0 - приготовить пиццу\n" +
//                     "1 - нарезать пиццу\n" +
//                     "2 - съесть пиццу\n" +
//                     "3 - показать параметры пиццы\n" +
//                     "4 - в главное меню\n");

//                     pizzaAction = Convert.ToInt16(Console.ReadLine());

//                     switch (pizzaAction)
//                     {
//                       case 0:
//                         formagiPizza.Bake();
//                         break;
//                       case 1:
//                         formagiPizza.Slice();
//                         break;
//                       case 2:
//                         formagiPizza.Eat();
//                         break;
//                       case 3:
//                         Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
//                         break;
//                     }
//                   } while (pizzaAction != 4);
//                 }
//                 else if (pizza.GetType() == typeof(Pepperoni))
//                 {
//                   Pepperoni pepperoniPizza = (Pepperoni)pizza;
//                   do
//                   {
//                     Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
//                     Console.WriteLine("\nДоступные действия:\n" +
//                     "0 - приготовить пиццу\n" +
//                     "1 - нарезать пиццу\n" +
//                     "2 - съесть пиццу\n" +
//                     "3 - добавить больше пепперони\n" +
//                     "4 - показать параметры пиццы\n" +
//                     "5 - в главное меню\n");

//                     pizzaAction = Convert.ToInt16(Console.ReadLine());

//                     switch (pizzaAction)
//                     {
//                       case 0:
//                         pepperoniPizza.Bake();
//                         break;
//                       case 1:
//                         pepperoniPizza.Slice();
//                         break;
//                       case 2:
//                         pepperoniPizza.Eat();
//                         break;
//                       case 3:
//                         pepperoniPizza.AddMorePepperoni();
//                         break;
//                       case 4:
//                         Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
//                         break;
//                     }
//                   } while (pizzaAction != 5);
//                 }
//                 else if (pizza.GetType() == typeof(JumboPepperoni))
//                 {
//                   JumboPepperoni jumboPepperoniPizza = (JumboPepperoni)pizza;
//                   do
//                   {
//                     Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
//                     Console.WriteLine("\nДоступные действия:\n" +
//                     "0 - приготовить пиццу\n" +
//                     "1 - нарезать пиццу\n" +
//                     "2 - съесть пиццу\n" +
//                     "3 - добавить больше пепперони\n" +
//                     "4 - добавить грибы\n" +
//                     "5 - показать параметры пиццы\n" +
//                     "6 - в главное меню\n");

//                     pizzaAction = Convert.ToInt16(Console.ReadLine());

//                     switch (pizzaAction)
//                     {
//                       case 0:
//                         jumboPepperoniPizza.Bake();
//                         break;
//                       case 1:
//                         jumboPepperoniPizza.Slice();
//                         break;
//                       case 2:
//                         jumboPepperoniPizza.Eat();
//                         break;
//                       case 3:
//                         jumboPepperoniPizza.AddMorePepperoni();
//                         break;
//                       case 4:
//                         jumboPepperoniPizza.AddMushrooms();
//                         break;
//                       case 5:
//                         Console.WriteLine($"\nПараметры пиццы:\n{pizza}\n{pizza.ClassName()}");
//                         break;
//                     }
//                   } while (pizzaAction != 6);
//                 }
//               }
//               break;
//             }
//         }
//       }
//     }
//   }
// }
