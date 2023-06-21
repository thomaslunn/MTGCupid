using MTGCupid.Matches;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.UI.PairingsView
{
    public interface IPairingControl
    {
        public static readonly Color RED = Color.FromArgb(0xff, 0x80, 0x80);
        public static readonly Color YELLOW = Color.FromArgb(0xff, 0xff, 0x80);
        public static readonly Color GREEN = Color.FromArgb(0x80, 0xff, 0x80);
        public static readonly Color YELLOW_GREEN = Color.FromArgb(0xc0, 0xc0, 0x00);

        public static readonly Color CONTROL_BACKGROUND = SystemColors.Control;
        public static readonly Color LIGHT_GREEN_BACKGROUND = Color.FromArgb(0xc0, 0xff, 0xc0);

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the score of the match is submitted or unsubmitted")]
        public event EventHandler<MatchSubmittedToggledEventArgs>? MatchSubmittedToggled;

        public static UserControl GetPairingControl(IMatch match)
        {
            switch(match)
            {
                case MultiplayerGame multiMatch:
                    return new MultiplayerGamePairingControl(multiMatch);
                case Match twoPlayerMatch:
                    return new TwoPlayerMatchPairingControl(twoPlayerMatch);
                case Bye byeMatch:
                    return new ByePairingControl(byeMatch);
                default:
                    throw new NotImplementedException();
            }
        }

        public abstract void DropPlayers();

        public abstract void Submit();
    }

    public class MatchSubmittedToggledEventArgs : EventArgs
    {
        public IMatch? Match { get; set; }
        public bool Submitted { get; set; }
    }
}
