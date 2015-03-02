using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.Model
{
    /// <summary>
    /// Represents a member
    /// </summary>
    class Member
    {
        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        public int birthday { get; set; }

        /// <summary>
        /// Gets or sets the accession day.
        /// </summary>
        public int accession { get; set; }

        /// <summary>
        /// Gets or sets the active state.
        /// </summary>
        public bool active { get; set; }
    }
}
