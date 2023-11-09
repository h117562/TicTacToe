
namespace tictactoe
{
    class Programs
    {

        static void Main(string[] args)
        {

            GameStart();

            return;
        }


        static void GameStart()
        {
            while (true)
            {
                char[,] fields = new char[7, 7]
                { { '┌', '―', '┬', '―', '┬', '―', '┐'},
              { '│', 'ㅤ', '│' ,'ㅤ', '│', 'ㅤ', '│'},
              { '├', '―', '┼' ,'―', '┼', '―', '┤'},
              { '│', 'ㅤ', '│' ,'ㅤ', '│', 'ㅤ', '│'},
              { '├', '―', '┼' ,'―', '┼', '―', '┤'},
              { '│', 'ㅤ', '│' ,'ㅤ', '│', 'ㅤ', '│'},
              { '└', '―', '┴', '―', '┴', '―', '┘'}
                 };

                char[,] check_field = new char[3, 3];
                             //그림 필드와 별개로 쉽게 승리체크하기 위해 새로운 배열로 계산
                int count = 1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        check_field[i, j] = (char)count;
                        count++;
                    }
                }

                count = 1;
                char stemp = '◆';
                bool whosTurn = true;

                while (true)
                {
                    Console.Clear();

                                    //둘곳이 없으면 게임 재시작
                    if (count == 10)
                    {
                        break;
                    }

                                    //바둑판 그리기
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            Console.Write(fields[i, j]);
                        }

                        Console.WriteLine();
                    }

                                    //승리 체크
                    if (check_field[0, 0] == check_field[1, 1] && check_field[2, 2] == check_field[1, 1])
                    {

                        Console.WriteLine("승리!");
                        return;
                    }
                                    //승리 체크
                    if (check_field[0, 2] == check_field[1, 1] && check_field[2, 0] == check_field[1, 1])
                    {

                        Console.WriteLine("승리!");
                        return;
                    }
                                     //승리 체크
                    for (int b = 0; b < 3; b++)
                    {

                        if (check_field[0, b] == check_field[1, b] && check_field[1, b] == check_field[2, b])
                        {
                            Console.WriteLine("승리!");
                            return;
                        }

                        if (check_field[b, 0] == check_field[b, 1] && check_field[b, 1] == check_field[b, 2])
                        {
                            Console.WriteLine("승리!");
                            return;
                        }
                    }


                    Console.WriteLine("1, 2, 3");
                    Console.WriteLine("4, 5, 6");
                    Console.WriteLine("7, 8, 9");
                    Console.Write("위치 입력해주세요 :");
                    string tmp = Console.ReadLine();

                                    //현재 누구 차례인지 따라 필드배열에 체크                                  
                    if (int.TryParse(tmp, out int a) && a > 0 && a < 10)
                    {
                        switch (int.Parse(tmp))
                        {
                            case 1:
                                if (fields[1, 1] != 'ㅤ') continue;
                                fields[1, 1] = stemp;
                                check_field[0, 0] = stemp;
                                break;
                            case 2:
                                if (fields[1, 3] != 'ㅤ') continue;
                                fields[1, 3] = stemp;
                                check_field[0, 1] = stemp;
                                break;
                            case 3:
                                if (fields[1, 5] != 'ㅤ') continue;
                                fields[1, 5] = stemp;
                                check_field[0, 2] = stemp;
                                break;
                            case 4:
                                if (fields[3, 1] != 'ㅤ') continue;
                                fields[3, 1] = stemp;
                                check_field[1, 0] = stemp;
                                break;
                            case 5:
                                if (fields[3, 3] != 'ㅤ') continue;
                                fields[3, 3] = stemp;
                                check_field[1, 1] = stemp;
                                break;
                            case 6:
                                if (fields[3, 5] != 'ㅤ') continue;
                                fields[3, 5] = stemp;
                                check_field[1, 2] = stemp;
                                break;
                            case 7:
                                if (fields[5, 1] != 'ㅤ') continue;
                                fields[5, 1] = stemp;
                                check_field[2, 0] = stemp;
                                break;
                            case 8:
                                if (fields[5, 3] != 'ㅤ') continue;
                                fields[5, 3] = stemp;
                                check_field[2, 1] = stemp;
                                break;
                            case 9:
                                if (fields[5, 5] != 'ㅤ') continue;
                                fields[5, 5] = stemp;
                                check_field[2, 2] = stemp;
                                break;

                        }
                    }
                    else
                        continue;


                                    //바톤터치
                    whosTurn = !whosTurn;

                    if (whosTurn == true)
                        stemp = '◆';
                    else
                        stemp = '◎';

                    count++;
                }
            }
        }
    }
}
