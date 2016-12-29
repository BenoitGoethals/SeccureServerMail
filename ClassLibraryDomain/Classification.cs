using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassLibraryDomain
{
    public class Classification: IComparable<Classification>
    {
        public int CompareTo(Classification other)
        {
            if (other == null) return -1;

            if (this.Organisation.Equals(other.Organisation))
            {
                return this.Ranking.CompareTo(other.Ranking);
            }
            return this.Organisation.CompareTo(other.Organisation);

        }

        public int Id { get; set; }
        public int Ranking { get; set; }
        public string Description { get; set; }
        public Organisation Organisation { get; set; }


        public Classification( int ranking, string description, Organisation organisation)
        {
           
            Ranking = ranking;
            Description = description;
            Organisation = organisation;
        }


        protected bool Equals(Classification other)
        {
            return Ranking == other.Ranking && Organisation == other.Organisation;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Classification) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Ranking*397) ^ (int) Organisation;
            }
        }


        public override string ToString()
        {
            return $"Id: {Id}, Ranking: {Ranking}, Description: {Description}, Organisation: {Organisation}";
        }
    }
}