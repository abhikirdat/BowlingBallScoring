
public class Program
{
    public static void Main(string[] args)
    {
        int bowlFirst = 0, bowlSecond = 0, frameScore = 0, totalScore = 0, prevFrame = 0, prevFrameTwo = 0, extraFrame = 0;
        bool strike = false, strikeTwo = false, spare = false,invalidInput = false; ;
        String frameNumber = string.Empty, lineToSeprate = string.Empty, score1 = string.Empty, score2 = string.Empty, LastFrameTwo = string.Empty, LastFrameThree = string.Empty;

        Console.WriteLine("Bowling ball scoring..");

        try
        {
            //Games for 10 frames
            for (int frameCount = 1; frameCount <= 10; frameCount++)
            {
                Console.WriteLine("Please Enter your Scores for {0} Frame :", frameCount);
                do
                {
                    invalidInput = false;
                    Console.Write("Bowl first :");

                    if (!int.TryParse(Console.ReadLine(), out bowlFirst))
                    {
                        invalidInput = true;
                        Console.WriteLine("invalid input try again ");
                    }
                } while (invalidInput || bowlFirst > 10 || bowlFirst < 0);

                if (spare == true)
                {
                    spare = false;
                    prevFrame = 10 + bowlFirst;  //Bonus: (10)spare pins + (bowlFirst)number of pins knocked down by the next roll.
                    totalScore = totalScore + prevFrame;
                    score2 = scoreTwo(totalScore, score2);
                }
                if (strikeTwo == true && bowlFirst == 10)
                {
                    prevFrameTwo = 30;  //strikeTwo 20 + bowlfirst 10
                    totalScore = totalScore + prevFrameTwo;
                    score2 = scoreTwo(totalScore, score2);
                }
                if (strikeTwo == true && bowlFirst != 10)
                {
                    strikeTwo = false;
                    prevFrameTwo = 10 + 10 + bowlFirst; //10+10 is equal to striketwo values + bowlFirst pins.
                    totalScore = totalScore + prevFrameTwo;
                    score2 = scoreTwo(totalScore, score2);
                }
                if (strike == true && bowlFirst == 10)
                {
                    strikeTwo = true;
                    prevFrameTwo = 20; // strike 10+ bowlfirst 10
                }

                if (bowlFirst < 10)
                {
                    do
                    {
                        invalidInput = false;
                        Console.Write("Bowl second :");
                        if (!int.TryParse(Console.ReadLine(), out bowlSecond))
                        {
                            invalidInput = true;
                            Console.WriteLine("invalid input try again ");
                        }
                    } while (invalidInput || bowlSecond > (10 - bowlFirst) || bowlSecond < 0);

                    if (bowlFirst + bowlSecond == 10)
                    {
                        spare = true;
                        score1 += bowlFirst + "-/ |";
                    }

                    if (strike == true && bowlFirst != 10)
                    {
                        strike = false;
                        prevFrame = 10 + bowlFirst + bowlSecond; //Bonus: (10)strike pins + (bowlFirst)+(bowlSecond)next two balls rolled bonus.
                        totalScore = totalScore + prevFrame;
                        score2 = scoreTwo(totalScore, score2);
                    }
                    if (strikeTwo == true && frameCount == 10)
                    {
                        strikeTwo = false;
                        prevFrameTwo = 10 + 10 + bowlSecond;
                        totalScore = totalScore + prevFrameTwo;
                        score2 = scoreTwo(totalScore, score2);
                    }
                    if (spare != true && strike != true && strikeTwo != true)  //no spare, No strike and no strike two
                    {
                        frameScore = bowlFirst + bowlSecond;   // add bowlfirst and bowlsecond
                        totalScore = totalScore + frameScore;
                        score2 = scoreTwo(totalScore, score2);
                        if (frameCount != 10)
                            score1 += " " + bowlFirst + "-" + bowlSecond + " |";
                        else
                            score1 += " " + bowlFirst + "-" + bowlSecond;
                    }
                }
                else
                {
                    strike = true;
                    prevFrame = 10;
                    if (frameCount != 10)
                        score1 += " X-  |";
                }

                if (frameCount == 10 && strike == true)  // if fream is 10th and strike is true accept next bawl pins
                {
                    do
                    {
                        invalidInput = false;
                        Console.Write("bonus bowl first :");
                        if (!int.TryParse(Console.ReadLine(), out bowlSecond))
                        {
                            invalidInput = true;
                            Console.WriteLine("invalid input try again ");
                        }
                    } while (invalidInput || bowlSecond < 0 || bowlSecond > 10);
                    if (strikeTwo == true)
                    {
                        prevFrameTwo = 10 + 10 + bowlSecond; //10+10 strikeTwo+ second bowl pins
                        totalScore = totalScore + prevFrameTwo;
                        score2 = scoreTwo(totalScore, score2);
                        strikeTwo = false;
                    }
                }
                if (frameCount == 10 && (spare == true || strike == true))
                {
                    do
                    {  
                        invalidInput = false;
                        Console.Write("bonus bowl second :");
                        if (!int.TryParse(Console.ReadLine(), out extraFrame))
                        {
                            invalidInput = true;
                            Console.WriteLine("invalid input try again ");
                        }
                    }
                    while (invalidInput || extraFrame < 0 || extraFrame > 10);
                    if (strike == true)
                    {
                        prevFrame = 10 + bowlSecond + extraFrame;
                        totalScore = totalScore + prevFrame;
                        score2 = scoreTwo(totalScore, score2);
                        if (bowlSecond == 10)
                            LastFrameTwo = "-X";
                        else
                            LastFrameTwo += bowlSecond;
                        if (extraFrame == 10)
                            LastFrameThree = "-X";
                        else
                            LastFrameThree += extraFrame;
                        score1 += " X" + LastFrameTwo + LastFrameThree;
                    }
                    else
                    {
                        if (extraFrame == 10)
                            LastFrameThree = "-X";
                        else
                            LastFrameThree += extraFrame;
                        if (bowlSecond + extraFrame == 10 && extraFrame != 10)
                            LastFrameThree = "-/";
                        else
                            LastFrameThree += extraFrame;
                        totalScore = totalScore + 10 + extraFrame;
                        score2 = scoreTwo(totalScore, score2);
                        score1 += bowlFirst + "-/" + LastFrameThree;
                    }
                }

                frameNumber += frameCount + "     ";
                lineToSeprate += "------";
            }
            Console.WriteLine(frameNumber);
            Console.WriteLine(lineToSeprate);
            Console.WriteLine(score1);
            Console.WriteLine(score2);
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            throw;
        }

    }
    static String scoreTwo(int totalScore, String score2)
    {
        score2 += totalScore + "     ";
        return score2;
    }
}