using BrokerDB;
using Domain;

namespace ControllerAP
{
    public class Controller
    {
        private static Controller instance;

        public static Controller Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }

        Broker broker = new Broker();

        public List<ExamPeriod> ReturnExamPeriods()
        {
            try
            {
                broker.OpenConn();
                return broker.ReturnExamPeriods();
            }
            finally
            {
                broker.CloseConn();
            }
        }

        public List<ExamPeriodCourse> ReturnCourses(int id)
        {
            try
            {
                broker.OpenConn();
                return broker.ReturnCourses(id);
            }
            finally
            {
                broker.CloseConn();
            }
        }

        
        public void AddCourseToExamPeriod(Course c, ExamPeriod ep, DateTime date)
        {
            try
            {
                broker.OpenConn();
                broker.AddCourseToExamPeriod(c, ep, date);
            }
            finally
            {
                broker.CloseConn();
            }
        }
    }
}