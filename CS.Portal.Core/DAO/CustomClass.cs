using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS.Portal.Core.EF;

namespace CS.Portal.Core.DAO
{
    public class jsTree
    {
        public jsTree()
        {
            icon = "fas fa-cubes";
            state = new jsTreeState();
        }
        public int id { get; set; }
        public string text { get; set; }
        public jsTreeState state { get; set; }
        public string icon { get; set; }
        public List<jsTree> children { get; set; }
    }

    public class jsTreeState
    {
        public jsTreeState()
        {
            opened = true;
            disabled = false;
            selected = false;
        }
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
    }

    public class MainMenu
    {
        public string stringMenu { get; set; }
        public List<int> roleMenu { get; set; }
    }

    public class PagePartialBox
    {
        public CSF_Pages_GetPartial_Result box { get; set; }
        public List<CSF_Pages_GetPartial_Result> boxChild { get; set; }
    }

    public class SubSelectBox
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentid { get; set; }
    }

}
