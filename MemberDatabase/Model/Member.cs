using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
        [PrimaryKey, MaxLength(20), NotNull]
        public string firstName { get; set; }

        [PrimaryKey, MaxLength(20), NotNull]
        public string lastName { get; set; }

        public int birthday { get; set; }

        public int accession { get; set; }

        public bool active { get; set; }
    }
}
