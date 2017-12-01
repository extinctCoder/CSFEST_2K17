using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peasy;

namespace Backend.DAL
{
    public partial class action : IDomainObject<int>
    {
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    public partial class component : IDomainObject<long>
    {
        public long ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    public partial class control_panel : IDomainObject<long>
    {
        public long ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    public partial class datum : IDomainObject<int>
    {
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    public partial class permission : IDomainObject<int>
    {
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    public partial class room :IDomainObject<int>
    {
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    public partial class scheduler : IDomainObject<int>
    {
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    public partial class switch_condition : IDomainObject<long>
    {
        public long ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    public partial class user : IDomainObject<int>
    {
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    public partial class user_group : IDomainObject<int>
    {
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
    class partialClasses
    {
    }
}
