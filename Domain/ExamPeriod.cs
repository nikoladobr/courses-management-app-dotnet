﻿namespace Domain
{
    public class ExamPeriod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}