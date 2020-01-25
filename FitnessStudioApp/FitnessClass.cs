using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessStudioApp
{

    /// <summary>
    /// This represents Fitness Studio App where customers can view, sign up for and withdraw from classes.
    /// </summary>
    class FitnessClass
    {
        # region Properties
        /// <summary>
        /// Unique Class ID
        /// </summary>
        public int ClassID { get; set; }
        
        /// <summary>
        /// Title e.g. Hatha Yoga, Zumba, Mat Pilates
        /// </summary>
        public string ClassTitle { get; set; }
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
        public DateTime ClassTimings { get; set; }
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
        public decimal Pricing { get; set; }
        /// <summary>
        /// Maximum number of participants allowed
        /// </summary>
        public int ClassSize { get; set; }
        /// <summary>
        /// Spaces still available for registration
        /// </summary>
        public int SpacesAvailable { get; set; }
        #endregion
    }
}
