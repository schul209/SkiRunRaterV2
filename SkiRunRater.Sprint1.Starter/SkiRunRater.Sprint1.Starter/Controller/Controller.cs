using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRunRater
{
    public class Controller
    {
        #region FIELDS

        bool active = true;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            ApplicationControl();
        }

        #endregion

        #region METHODS

        private void ApplicationControl()
        {
            SkiRunRepository skiRunRepository = new SkiRunRepository();

            ConsoleView.DisplayWelcomeScreen();

            using (skiRunRepository)
            {
                List<SkiRun> skiRuns = skiRunRepository.GetSkiAllRuns();

                while (active)
                {
                    
                    AppEnum.ManagerAction userActionChoice;

                    int skiRunID = 1;
                    SkiRun skiRun = new SkiRun();
                    string message;

                    userActionChoice = ConsoleView.GetUserActionChoice();

                    switch (userActionChoice)
                    {
                        case AppEnum.ManagerAction.None:
                            break;
                        case AppEnum.ManagerAction.ListAllSkiRuns:
                            ConsoleView.DisplayAllSkiRuns(skiRuns);
                            ConsoleView.DisplayContinuePrompt();
                            break;
                        case AppEnum.ManagerAction.DisplaySkiRunDetail:
                             ConsoleView.GetSkiRunID(skiRuns);
                            skiRunRepository.GetSkiRunByID(skiRunID);
                            break;
                        case AppEnum.ManagerAction.DeleteSkiRun:
                            ConsoleView.GetSkiRunID(skiRuns);
                            skiRunRepository.DeleteSkiRun(skiRunID);
                            ConsoleView.DisplayReset();
                            ConsoleView.DisplayMessage($"Ski Run ID:" + skiRunID +  "has been deleted.");
                            ConsoleView.DisplayContinuePrompt();
                            break;
                        case AppEnum.ManagerAction.AddSkiRun:
                            ConsoleView.DisplayReset();
                            ConsoleView.GetAddSkiRun(skiRun);
                            skiRunRepository.InsertSkiRun(skiRun);
                            
                            break;
                        case AppEnum.ManagerAction.UpdateSkiRun:
                            break;
                        case AppEnum.ManagerAction.QuerySkiRunsByVertical:

                            break;
                        case AppEnum.ManagerAction.Quit:
                            active = false;
                            break;
                        default:
                            break;
                    }
                }
            }

            ConsoleView.DisplayExitPrompt();
        }

        #endregion

    }
}
