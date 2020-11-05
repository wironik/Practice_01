using System;
using System.Runtime.CompilerServices;

namespace SVM_Task_04
{
    class Task4
    {
        public static double PlayerDamage(Player AttackingName, Player name, double damage, double health, double HP)
        {
            if (name.HideActive == false)
            {
                Console.WriteLine(AttackingName.name + " атакует!");
                Console.WriteLine("Урон " + name.name + ": -" + damage);
                HP = HP - damage;
            }
            else
            {
                Console.WriteLine(AttackingName.name + " не смог нанести урон!");
                Console.WriteLine(name.name + " в укрытии: ");
                health = name.HidePlayer(health);
                Console.WriteLine("Здоровье " + name.name + ": +" + health);
                HP = HP + health;
            }
            return HP;
        }
        public static void PlayerStep(int step)
        {
            if (step == 1)
            {
                Console.WriteLine("\nХОДИТ ИГРОК");
                Console.WriteLine("Доступные действия: ");
                Console.WriteLine("A: Ударить мечом");
                Console.WriteLine("B: Применить супер атаку");
                Console.WriteLine("C: Укрыться за камнем");
                Console.WriteLine("D: Восстановить здоровье");
                Console.WriteLine("E: Призвать помощника");
                Console.WriteLine("\n Для выбора действия нажмите нужную букву: ");
                Console.WriteLine("Чтобы посмотреть информацию об игре и атаках, нажмите любую клавишу:");
            }
            else
            {
                Console.WriteLine("\nХОДИТ БОСС");
            }
        }
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            Player User = new Player();
            User.name = "Том";
            User.status = "Воин";
            User.HP = rnd.Next(249, 301);
            User.AmountHealth = rnd.Next(3, 6);

            Player Boss = new Player();
            Boss.name = "Николас";
            Boss.status = "Враг";
            Boss.HP = rnd.Next(249, 301);
            Boss.AmountHealth = rnd.Next(3, 6);

            Player Helper = new Player();
            Helper.name = "Верный Пес-воин";
            Helper.status = "Помощник";
            Helper.HP = rnd.Next(59, 81);

            Player Skeleton = new Player();
            Skeleton.name = "Вражеский Скелет";
            Skeleton.status = "Помощник";
            Skeleton.HP = rnd.Next(59, 81);

            Console.WriteLine("\nИНФОРМАЦИЯ");
            User.GetInfoPlayer();
            Boss.GetInfoPlayer();
            Helper.GetInfoPlayer();
            Skeleton.GetInfoPlayer();

            int step = rnd.Next(0, 2);
            double HelperHP = Helper.HP;
            double SkeletonHP = Skeleton.HP;
            double damage = 0;
            double health = 0;
            double BossHP = Boss.HP;
            double UserHP = User.HP;

            while((UserHP>0)&&(BossHP>0))
            {
                if (step == 1)
                {
                    PlayerStep(step);
                    Console.WriteLine("\nДополнительная информация:");
                    if (Helper.HelperActive == true && Helper.HP > 0)
                        Console.WriteLine("Ваш помощник уже призван");
                    else if (HelperHP <= 0)
                        Console.WriteLine("Ваш помощник мертв");
                    else
                        Console.WriteLine("Ваш помощник еще не был призван");
                    Console.WriteLine("Для использования супер атаки необходимо энергии: 5");
                    Console.WriteLine("Накопленная энергия: "+User.power);
                    Console.WriteLine("Количество оставшихся зелий: "+User.AmountHealth);
                    Console.WriteLine("Вы можете спрятаться еще "+User.AmountHide+" раз");

                    ConsoleKeyInfo choise = Console.ReadKey();
                    while (choise.Key != ConsoleKey.A && choise.Key != ConsoleKey.B && choise.Key != ConsoleKey.C && choise.Key != ConsoleKey.D && choise.Key != ConsoleKey.E)
                    {
                        User.GetInfoGame();
                        Console.WriteLine("\nЧтобы продолжить игру выберите действие: ");
                        choise = Console.ReadKey();
                    }
                    Console.Clear();
                    if (choise.Key == ConsoleKey.A)
                    {
                        if (Skeleton.HelperActive == true)
                        {
                            damage = User.Attack(damage);
                            SkeletonHP = PlayerDamage(User, Skeleton, damage, health, SkeletonHP);
                            Skeleton.CallHelper(SkeletonHP);
                        }
                        else
                        {
                            damage = User.Attack(damage);
                            BossHP = PlayerDamage(User, Boss, damage, health, BossHP);
                        }
                    }
                    else if (choise.Key == ConsoleKey.B)
                    {
                        if (Skeleton.HelperActive == true)
                        {
                            damage = User.PowerAttack(damage);
                            SkeletonHP = PlayerDamage(User, Skeleton, damage, health, SkeletonHP);
                            Skeleton.CallHelper(SkeletonHP);
                        }
                        else
                        {
                            damage = User.PowerAttack(damage);
                            BossHP = PlayerDamage(User, Boss, damage, health, BossHP);
                        }
                    }
                    else if (choise.Key == ConsoleKey.C)
                    {
                        if (User.AmountHide <= 0)
                        {
                            Console.WriteLine(User.name + " не смог спрятаться!");
                        }
                        else
                        {
                            Console.WriteLine(User.name + " спрятался за камнем!");
                            User.HidePlayer(health);
                        }
                    }
                    else if (choise.Key == ConsoleKey.D)
                    {
                        if ((User.AmountHealth > 0) && (User.HP / 2 > UserHP))
                        {
                            Console.WriteLine(User.name + " восстановил здоровье!");
                            health=User.HealthRecovery(health);
                            UserHP = UserHP + health;
                            Console.WriteLine("Здоровье " + User.name + ": +" + health);
                        }
                        else if (User.AmountHealth <= 0)
                        {
                            Console.WriteLine("Зелья закончились!");
                        }
                        else if (User.HP / 2 <= UserHP)
                            Console.WriteLine("У вас больше половина здоровья!");

                    }
                    else if (choise.Key == ConsoleKey.E)
                    {
                        if (UserHP / User.HP * 100 <= 25)
                        {
                            Console.WriteLine(User.name + " призвал помощника!");
                            HelperHP = Helper.CallHelper(HelperHP);
                        }
                        else
                            Console.WriteLine(User.name + " не смог призвать помощника!");
                    }
                    Console.WriteLine("Текущее здоровье " + User.name + ": " + Math.Round(UserHP / User.HP* 100,2) + "%");
                    Console.WriteLine("Текущее здоровье " + Boss.name + ": " + Math.Round(BossHP / Boss.HP * 100,2) + "%");
                    if (Helper.HelperActive == true)
                        Console.WriteLine("Текущее здоровье " + Helper.name + ": " + Math.Round(HelperHP / Helper.HP * 100,2) + "%");
                    if (Skeleton.HelperActive == true)
                        Console.WriteLine("Текущее здоровье " + Skeleton.name + ": " + Math.Round(SkeletonHP / Skeleton.HP * 100,2) + "%");
                    step = 0;    
                }
                else
                {
                    PlayerStep(step);
                    int choise = rnd.Next(1,6);
                    if (choise == 1)
                    {
                        if (Helper.HelperActive == true)
                        {
                            damage = Boss.Attack(damage);
                            HelperHP = PlayerDamage(Boss, Helper, damage, health, HelperHP);
                            Helper.CallHelper(HelperHP);
                        }
                        else
                        {
                            damage = Boss.Attack(damage);
                            UserHP = PlayerDamage(Boss, User, damage, health, UserHP);
                        }
                    }
                    else if (choise == 2)
                    {
                        if (Helper.HelperActive == true)
                        {
                            damage = Boss.PowerAttack(damage);
                            HelperHP = PlayerDamage(Boss, Helper, damage, health, HelperHP);
                            Helper.CallHelper(HelperHP);
                        }
                        else
                        {
                            damage = Boss.PowerAttack(damage);
                            UserHP = PlayerDamage(Boss, User, damage, health, UserHP);
                        }
                    }
                    else if (choise == 3)
                    {
                        if (Boss.AmountHide>=2)
                        {
                            Console.WriteLine(Boss.name + " спрятался за камнем!");
                            Boss.HidePlayer(health);
                        }
                        else
                        {
                            Console.WriteLine(Boss.name + " не смог спрятаться!");
                            if (Helper.HelperActive == true)
                            {
                                damage = Boss.Attack(damage);
                                HelperHP = PlayerDamage(Boss, Helper, damage, health, HelperHP);
                                Helper.CallHelper(HelperHP);
                            }
                            else
                            {
                                damage = Boss.Attack(damage);
                                UserHP = PlayerDamage(Boss, User, damage, health, UserHP);
                            }
                        }
                    }
                    else if (choise == 4)
                    {
                        if ((Boss.AmountHealth > 0) && (Boss.HP / 2 > BossHP))
                        {
                            Console.WriteLine(Boss.name + " восстановил здоровье!");
                            health=Boss.HealthRecovery(health);
                            BossHP = BossHP + health;
                            Console.WriteLine("Здоровье " + Boss.name + ": +" + health);
                        }
                        else if (Boss.AmountHealth <= 0)
                        {
                            Console.WriteLine(Boss.name+ " не смог выпить зелье!");
                            if (Helper.HelperActive == true)
                            {
                                damage = Boss.Attack(damage);
                                HelperHP = PlayerDamage(Boss, Helper, damage, health, HelperHP);
                                Helper.CallHelper(HelperHP);
                            }
                            else
                            {
                                damage = Boss.Attack(damage);
                                UserHP = PlayerDamage(Boss, User, damage, health, UserHP);
                            }
                        }
                        else if(Boss.HP / 2 <= BossHP)
                        {
                            Console.WriteLine(Boss.name+" не смог выпить зелье!");
                            if (Helper.HelperActive == true)
                            {
                                damage = Boss.Attack(damage);
                                HelperHP = PlayerDamage(Boss, Helper, damage, health, HelperHP);
                                Helper.CallHelper(HelperHP);
                            }
                            else
                            {
                                damage = Boss.Attack(damage);
                                UserHP = PlayerDamage(Boss, User, damage, health, UserHP);
                            }
                        }
                    }
                    else if (choise == 5)
                    {
                        if(BossHP/Boss.HP*100<=50)
                        {
                            Console.WriteLine(Boss.name + " призвал помощника!");
                            SkeletonHP = Skeleton.CallHelper(SkeletonHP);
                        }
                        else
                            Console.WriteLine(Boss.name + " не смог призвать помощника!");
                    }
                    Console.WriteLine("Текущее здоровье " + User.name + ": " + Math.Round(UserHP / User.HP * 100, 2) + "%");
                    Console.WriteLine("Текущее здоровье " + Boss.name + ": " + Math.Round(BossHP / Boss.HP * 100, 2) + "%");
                    if (Helper.HelperActive == true)
                        Console.WriteLine("Текущее здоровье " + Helper.name + ": " + Math.Round(HelperHP / Helper.HP * 100, 2) + "%");
                    if (Skeleton.HelperActive == true)
                        Console.WriteLine("Текущее здоровье " + Skeleton.name + ": " + Math.Round(SkeletonHP / Skeleton.HP * 100, 2) + "%");
                    step = 1;
                }
            }
            if ((UserHP <= 0)&&(BossHP <= 0))
                Console.WriteLine("\nВы и босс умерли одновременно.\n\n\n");
            else if (UserHP <= 0)
                Console.WriteLine("\nВы проиграли. Победил враг.\n\n\n");
            else if (BossHP <= 0)
                Console.WriteLine("\nВы выиграли. Враг умер.\n\n\n");
        }
    }
    class Player
    {
        public string name; //имя
        public string status; //статус
        public double HP; //кол-во жизней
        public bool HideActive = false; //спрятался ли игрок
        public bool HelperActive = false; //активный ли помощник
        public int AmountHealth;
        public int AmountHide = 2;
        public void GetInfoPlayer()
        {
            Console.WriteLine("\nИнформация об игроке "+name+":");
            Console.WriteLine("Статус: " + status);
            Console.WriteLine("Текущее здоровье: " + HP);
            if (status=="Помощник")
                Console.WriteLine("Активность: " + HelperActive);
        }
        public void GetInfoGame()
        {
            Console.WriteLine("\n________________________________________________________");
            Console.WriteLine("ИНФОРМАЦИЯ ОБ ИГРЕ:\n");
            Console.WriteLine("\nПравила игры: \nВам необходимо убить Босса, используя различные действия. ");
            Console.WriteLine("A: Простая атака\nИспользуя это действие, игрок или босс может нанести от 24 до 31 урона, а если был призван помощник, " +
                "то совместная атака может быть от 33 до 47. Атака подействует только в том случае, если соперник не спрятался.\n" +
                "B: Сильная атака\nИспользуя это действие, игрок или босс может нанести от 49 до 76 урона вне зависимости от того, призван ли помощник " +
                "или нет. Сильную атаку можно использовать только в том случае, если у пользователя накопилось достаточно энергии. Энергию можно получить " +
                "используя простую атаку. 1 простая атака = 1 очко энергии. Для сильной атаки требуется минимум 5 очков энергии. Атака не сработает, если соперник " +
                "спрятался.\nC: Спрятаться\nДанная способность может быть использована только 2 раза за всю игру. Она позволяет пользователю спрятаться " +
                "и в течение 3х ходов восстанавливать здоровье от 3 до 6 единиц за ход. Урон игроку не наносится. Если пользователь спрятан и при этом смог атаковать, то здоровье " +
                "не восстанавливается, аналогично с сильной атакой.\nD: Восстановить здоровье\nДанное действие можно использовать только когда здоровье игрока " +
                "осталось меньше половины. Всего лекарств у игрока может быть от 3 до 5 за всю игру. Если лечиться будучи не спрятавшись, то здоровье восстановится от 24 до " +
                "31, а если игрок в укрытии, то от 27 до 37.\nE:Призвать помощника\nДанное действие можно применить только в том случае, если у пользователя осталось менее " +
                "25 процентов здоровья. Помощника можно призвать только один раз. Он увеличивает урон обычной атаки игрока, на сильную атаку не влияет, а также когда его атакует " +
                "враг, то урон получает помощник. \nИтоги игры\nПроигрывает тот, у кого первым закончатся жизни.\nУдачной игры!");
        }
        public int power = 0;
        int HideTime = 3;
        Random rnd = new Random();
        public double Attack(double damage) //обычная атака
        {
            if (HelperActive == false)
                damage = rnd.Next(24, 31);
            else
                damage = rnd.Next(33, 47);
            power++;
            return damage;
        }
        public double HealthRecovery(double health) //восстановление здоровья
        {
            if (HideActive == false)
            {
                health = rnd.Next(24, 31);
            }
            else
            {
                health = rnd.Next(27, 37);
                HideTime--;
            }
            AmountHealth--;
            //Console.WriteLine("health: " + health); работает
            return health;
        }
        public double PowerAttack(double damage) //супер атака
        {
            if (power >= 5)
            {
                Console.WriteLine("критический урон!");
                damage = rnd.Next(49, 76);
                power = power - 5;
            }
            else
                damage = Attack(damage);
            return damage;
        }
        public double HidePlayer(double health) //спрятаться на три хода
        {
            if (HideTime > 0)
            {
                HideActive = true;
                HideTime--;
                Console.WriteLine("Оставшееся время скрытия: "+HideTime);
                health = rnd.Next(3, 7);
            }
            else
            {
                HideActive = false;
                HideTime = 3;
                AmountHide--;
                Console.WriteLine("Время скрытия закончилось!");
            }
            return health;
        }
        public double CallHelper(double HP) //призвать помощника
        {
            if(HP>=0)
                HelperActive = true;
            else
            {
                HelperActive = false;
                Console.WriteLine("Сожалеем, "+name+" умер...");
            }
            return HP;
        }
    }
}
