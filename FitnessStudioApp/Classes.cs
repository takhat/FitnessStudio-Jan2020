using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessStudioApp
{
    enum TitleofClass
    {
        CrossFit,
        HathaYoga,
        MatPilates,
        PowerYoga,
        Swimming,
        ZumbaFitness,
        FlexFit
    };

    enum TypeOfMembership
    {
        FreeTrial=0,
        SingleClassPass = 20,
        TenClassPass = 180,
        TwentyClassPass = 350,
        MonthlyFlexFitPass = 200,
        QuarterlyFlexFitPass = 500,
        AnnualFlexFitPass = 900
    };
    // This represents Fitness Studio App where customers can view, sign up for and withdraw from classes.
    /// </summary>
    class Classes
    {
        private static int lastClassID = 100;
        private static int SignUpCount = 0;
        
        # region Properties
        /// <summary>
        /// Unique Class ID
        /// </summary>
        public int ClassID { get; private set; }
        /// <summary>
        /// Select the class Title
        /// </summary>
        public TitleofClass ClassTitle { get; set; }
        /// <summary>
        /// A detailed description of the class
        /// </summary>
        public string ClassDescription { get; set; }
        /// <summary>
        /// Minimum age required to participate in the class
        /// </summary>
        public int MinimumAge { get; set; }
        /// <summary>
        /// Days when the class is offered e.g. Tuesdays
        /// </summary>
        public DayOfWeek DaysClassOffered { get; set; }
        /// <summary>
        /// Class Time e.g. 9-10 AM
        /// </summary>
        public string ClassTimings { get; set; }
        /// <summary>
        /// First day of the class
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Last day of the class
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Name of the instructor assigned
        /// </summary>
        public string Instructor { get; set; }
        /// <summary>
        /// Pricing options e.g. Single class, 10-class pass, Monthly pass
        /// </summary>
        public TypeOfMembership MembershipType { get; set; }
        /// <summary>
        /// Maximum number of participants allowed
        /// </summary>
        public int ClassSize { get; set; }
        /// <summary>
        /// Spaces still available for registration
        /// </summary>
        public int SpacesAvailable { get; set; }
        public int SignedUpCustomerID { get; set; }
        #endregion


        #region Constructor
        public Classes()
        {
            ClassID = ++lastClassID;
            
        }
        #endregion
        #region Methods
        public void SignUp(int CustomerID, TypeOfMembership Price)

        {
            SignUpCount = ++SignUpCount;
            SpacesAvailable = ClassSize - SignUpCount;
            SignedUpCustomerID = CustomerID;
            MembershipType = Price;
        }
        #endregion
    }
}
