using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Current type of value in a cell
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// The cell hasn't been clicked
        /// </summary>
        Free,

        /// <summary>
        /// the cell is a 0
        /// </summary>
        Nought,

        /// <summary>
        /// The cell is a X
        /// </summary>
        Cross
    }
}
