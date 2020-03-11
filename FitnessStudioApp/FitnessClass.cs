using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace FitnessStudioApp
{
    // This represents Fitness Studio App where customers can view, sign up for and withdraw from classes.
    /// </summary>
    enum TitleofClass
    {
        CrossFit=100,
        HathaYoga=101,
        MatPilates=102,
        PowerYoga=103,
        Swimming=104,
        ZumbaFitness=105,
    };

    class FitnessClass
    {
        private int SignUpCount = 0;
        # region Properties
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
        public string StartDate { get; set; }
        /// <summary>
        /// Last day of the class
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// Name of the instructor assigned
        /// </summary>
        public string Instructor { get; set; }   
        /// <summary>
        /// Maximum number of participants allowed
        /// </summary>
        public int ClassSize { get; set; }
        /// <summary>
        /// Spaces still available for registration
        /// </summary>
        public int SpacesAvailable { get; set; }
        #endregion
        #region Methods
        public void UpdateClassSize()
        {
            SignUpCount = ++SignUpCount;
            SpacesAvailable = ClassSize - SignUpCount;
        }
        #endregion
    }
}
