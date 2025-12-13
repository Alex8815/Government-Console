using GovernmentMain.Helpers;
using GovernmentMain.Objects.EconomicConcepts;
using GovernmentMain.Objects.SocietyConcepts.Corporations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentMain.Objects.Government.Departments
{
    public class DepartmentOfEducation
    {
        private Gov _gov;
        public Wallet Funds { get; private set; }

        public Person Administrator { get; set; }

        public List<School> PublicSchools { get; private set; } = new List<School>();
        public List<School> AllSchools { get; private set; } = new List<School>();

        public DepartmentOfEducation(Gov gov, long initialFunds) {
            _gov = gov;
            Funds = new Wallet(initialFunds);
        }

        public void Fund(long newFunds)
        {
            Console.WriteLine($"Department of Education has been given ${newFunds} to fund schools");
            //Add total funds
            Funds.AddFunds(newFunds, FundsType.Funding);

            //allocate funds
            long forSchools = Maths.GrabMoneyPercent(80, newFunds);
            Funds.RemoveFunds(forSchools);

            //
            FundPublicSchools(forSchools);
        }

        //manage schools

        public void RegisterPublicSchool(School school)
        {
            AllSchools.Add(school);
            PublicSchools.Add(school);
        }
        public void DeregisterPublicSchool(School school)
        {
            PublicSchools.Remove(school);
        }
        public void DestroySchool(School school)
        {
            AllSchools.Remove(school);
            if (PublicSchools.Contains(school))
            {
                PublicSchools.Remove(school);
            }
        }

        public void FundPublicSchools(long fundsForSchools)
        {
            if (PublicSchools.Count == 0) return;
            //divide it amongst all schools, this likely will be weighted somehow?
            long fundsPer = (long)(fundsForSchools / PublicSchools.Count);
            foreach (School school in PublicSchools)
            {
                if (Funds.AttemptRemoveFunds(fundsForSchools))
                {
                    school.Fund(fundsPer);
                }
            }
        }

        public void AllSchools_Do()
        {
            foreach (School school in AllSchools)
            {
                school.Educate();
            }
        }

        //
        public void DepartmentOfEducation_Do()
        {
            AllSchools_Do();

        }

        
    }
}
