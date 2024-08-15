using System;

namespace BagratFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSayInsult = "1";
            const string CommandHitToFace = "2";
            const string CommandGetMother = "3";
            const string CommandDrinkBeer = "4";
            const string SampleInsultText1 = "иди нахуй!";
            const string SampleInsultText2 = "ты долбаеб";
            const string SampleInsultText3 = "от тебя воняет, как от мешка с говном";
            const string SampleInsultText4 = "ты чорт блять!";
            const int SampleInsultNumber1 = 1;
            const int SampleInsultNumber2 = 2;
            const int SampleInsultNumber3 = 3;
            const int SampleInsultNumber4 = 4;
            const int MinUserDamage = 5;
            const int MaxUserDamage = 10;
            const int MinEnemyDamage = 10;
            const int MaxEnemyDamage = 20;
            const int MinScore = 10;
            const int MaxScore = 20;
            const int GetMothetPrice = 100;
            const int NotherDamage = 50;
            const int MinUserAddHealth = 10;
            const int MaxUserAddHealth = 20;
            const int MinEnemyAddHealth = 5;
            const int MaxEnemyAddHealth = 10;
            const int MaxUserHealth = 100;
            const int MaxEnemyHealth = 100;

            Random userAddHealthGenerate = new Random();
            Random enemyAddHealthGenerate = new Random();
            Random userDamageGenerate = new Random();
            Random enemyDamageGenerate = new Random();
            Random scoreGenerate = new Random();
            Random insultGenerate = new Random();

            int userHealth = 100;
            int enemyHealth = 100;
            int userScore = 0;
            int enemyScore = 0;
            int userAddHealth;
            int enemyAddHealth;
            int userDamage;
            int enemyDamage;
            int selectInsult;

            string userName;
            string enemyName = "Баграт";
            string userShowAction = "стоит на месте";
            string enemyShowAction = "стоит на месте";
            string insultText = null;
            string selectUserAction;

            bool isUserAlive = true;
            bool isEnemyAlive = true;
            bool isUserDrankBeer = false;
            bool isEnemyDrankBeer = false;
            bool isUserSaidInsult = false;
            bool isEnemySaidInsult = false;

            Console.Write("Введите ваше имя: ");
            userName = Console.ReadLine();
            Console.Clear();
            Console.Write($"Добро пожаловать, {userName}!\n" +
                          $"Тебе сейчас предстоит сразиться с главным боссом, которого зовут - {enemyName}.\n\n" +
                           "Если ты еще не испугался и готов пройти эту игру, я расскажу тебе о правилах:\n" +
                           "1. Ты не можешь ударить противника, пока не оскорбишь его.\n" +
                           "2. Ты не можешь позвать маму разобраться, пока не наберешь 100 очков.\n" +
                           "3. Ты не можешь выпить пива больше 1 раза подряд.\n\n" +
                           "Нажмите на любую клавишу, чтобы продолжить. . .");

            Console.ReadKey();

            while (isUserAlive && isEnemyAlive)
            {
                if (userHealth <= 0) 
                {
                    isUserAlive = false;
                }

                if (enemyHealth <= 0) 
                {
                    isEnemyAlive = false;
                }

                Console.Clear();

                Console.WriteLine($"Здоровье {userName}: {userHealth} | Здоровье {enemyName}: {enemyHealth} | Очки: {userScore}\n");
                Console.WriteLine($"{userName} {userShowAction}\n{enemyName} {enemyShowAction}\n");
                Console.WriteLine("Выберите действие: \n" +
                                 $"{CommandSayInsult}. Сказать оскорбление\n" +
                                 $"{CommandHitToFace}. Дать по ебалу\n" +
                                 $"{CommandGetMother}. Позвать маму\n" +
                                 $"{CommandDrinkBeer}. Выпить банку пива\n");

                Console.SetCursorPosition(19, 5);

                selectUserAction = Console.ReadLine();

                if (isEnemyDrankBeer == false && enemyHealth < MaxEnemyHealth)
                {
                    isEnemyDrankBeer = true;
                    enemyAddHealth = enemyAddHealthGenerate.Next(MinEnemyAddHealth, MaxEnemyAddHealth + 1);
                    enemyHealth += enemyAddHealth;

                    if (enemyHealth > MaxEnemyHealth)
                    {
                        enemyHealth = MaxEnemyHealth;
                    }

                    enemyShowAction = "выпил банку пива!";
                }

                else if (enemyScore >= GetMothetPrice)
                {
                    enemyScore -= GetMothetPrice;
                    userHealth -= NotherDamage;
                    enemyShowAction = $"позвал свою маму и она отвесила пиздюлей игроку {userName}.";
                    isEnemyDrankBeer = false;
                }

                else if (isEnemySaidInsult == false)
                {
                    selectInsult = insultGenerate.Next(SampleInsultNumber1, SampleInsultNumber4 + 1);

                    switch (selectInsult)
                    {
                        case SampleInsultNumber1:
                            insultText = SampleInsultText1;
                            break;

                        case SampleInsultNumber2:
                            insultText = SampleInsultText2;
                            break;

                        case SampleInsultNumber3:
                            insultText = SampleInsultText3;
                            break;

                        case SampleInsultNumber4:
                            insultText = SampleInsultText4;
                            break;
                    }

                    enemyShowAction = $"сказал: {userName}, {insultText}";

                    isEnemySaidInsult = true;
                    isEnemyDrankBeer = false;
                }

                else
                {
                    enemyDamage = enemyDamageGenerate.Next(MinEnemyDamage, MaxEnemyDamage + 1);
                    userHealth -= enemyDamage;
                    enemyScore += scoreGenerate.Next(MinScore, MaxScore);
                    enemyShowAction = $"дал в ебало игроку {userName}";
                    isEnemySaidInsult = false;
                }

                switch (selectUserAction)
                {
                    case CommandSayInsult:

                        selectInsult = insultGenerate.Next(SampleInsultNumber1, SampleInsultNumber4 + 1);

                        switch (selectInsult)
                        {
                            case SampleInsultNumber1:
                                insultText = SampleInsultText1;
                                break;

                            case SampleInsultNumber2:
                                insultText = SampleInsultText2;
                                break;

                            case SampleInsultNumber3:
                                insultText = SampleInsultText3;
                                break;

                            case SampleInsultNumber4:
                                insultText = SampleInsultText4;
                                break;
                        }

                        userShowAction = $"сказал: {enemyName}, {insultText}";

                        isUserSaidInsult = true;
                        isUserDrankBeer = false;

                        break;

                    case CommandHitToFace:

                        if (isUserSaidInsult == false)
                        {
                            userShowAction = $"не может ударить игрока {enemyName}, пока не оскорбит его и пропускает ход";
                        }

                        else
                        {
                            userDamage = userDamageGenerate.Next(MinUserDamage, MaxUserDamage + 1);
                            enemyHealth -= userDamage;
                            userScore += scoreGenerate.Next(MinScore, MaxScore);
                            userShowAction = $"дал в ебало игроку {enemyName}";
                            isUserSaidInsult = false;
                        }

                        isUserDrankBeer = false;
                        break;

                    case CommandGetMother:

                        if (userScore < GetMothetPrice)
                        {
                            userShowAction = $"не может позвать маму, так как у него не хватает {GetMothetPrice - userScore} очков и пропускает ход.";
                        }

                        else
                        {
                            userScore -= GetMothetPrice;
                            enemyHealth -= NotherDamage;
                            userShowAction = $"позвал свою маму и она отвесила пиздюлей игроку {enemyName}.";

                        }

                        isUserDrankBeer = false;

                        break;

                    case CommandDrinkBeer:

                        if (isUserDrankBeer == true)
                        {
                            userShowAction = "не может выпить пиво 2 раза подряд и пропускает ход";
                        }

                        else
                        {
                            isUserDrankBeer = true;
                            userAddHealth = userAddHealthGenerate.Next(MinUserAddHealth, MaxUserAddHealth + 1);
                            userHealth += userAddHealth;

                            if (userHealth > MaxUserHealth)
                            {
                                userHealth = MaxUserHealth;
                            }

                            userShowAction = "выпил банку пива!";
                        }

                        break;

                    default:
                        userShowAction = "выбрал действие, которого не существует и пропускает ход";
                        isUserDrankBeer = false;
                        break;
                }
            }

            Console.Clear();

            if (isUserAlive == false && isEnemyAlive == false)
            {
                Console.WriteLine($"Игроки {userName} и {enemyName} захуярили друг друга. Никто не остался в живых.");
            }

            else if (isUserAlive == false)
            {
                Console.WriteLine($"Вы проиграли! Позор вам! Мы всем расскажем, что вы лох и вас отпиздил {enemyName}!");
            }

            else
            {
                Console.WriteLine("Поздравляем! Вы выиграли!!111! Уважение вам и почет!");
            }

            Console.ReadKey();
        }
    }
}
