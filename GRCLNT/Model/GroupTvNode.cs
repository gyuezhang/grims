using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT
{
    public enum GroupType
    {
        Company,
        Dept,
        User,
    }
    public class GroupTvNode : PropertyChangedBase
    {
        private GroupType _type;
        private int _id;
        private string _name;
        private List<GroupTvNode> _childs;
        private bool _exp;

        public GroupTvNode()
        {
            Exp = true;
            _childs = new List<GroupTvNode>();
        }

        public void Update(List<Dept> depts,List<User> users)
        {
            List<GroupTvNode> newChilds = new List<GroupTvNode>();
            Type = GroupType.Company;
            Id = 0;
            Name = "宝坻区地下水资源办公室";
            foreach(Dept dept in depts)
            {
                if (dept.id == -1)
                    continue;
                GroupTvNode deptNode = new GroupTvNode();
                deptNode.Id = dept.id;
                deptNode.Name = dept.name;
                deptNode.Type = GroupType.Dept;
                foreach(User user in users)
                {
                    if(user.deptid == deptNode.Id)
                    {
                        GroupTvNode userNode = new GroupTvNode();
                        userNode.Id = user.id;
                        userNode.Name = user.name;
                        userNode.Type = GroupType.User;
                        deptNode.Childs.Add(userNode);
                    }
                }
                newChilds.Add(deptNode);
            }
            Childs = newChilds;
        }

        public GroupType Type
        {
            get { return _type; }
            set
            {
                SetAndNotify(ref _type, value);
            }
        }

        public bool Exp
        {
            get { return _exp; }
            set
            {
                SetAndNotify(ref _exp, value);
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                SetAndNotify(ref _id, value);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                SetAndNotify(ref _name, value);
            }
        }

        public List<GroupTvNode> Childs
        {
            get { return _childs; }
            set
            {
                SetAndNotify(ref _childs, value);
            }
        }
    }
}
