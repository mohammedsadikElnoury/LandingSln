using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocket
{
    public class RocketLanding: IRocketLanding
    {
        #region Members
        private List<int> historyPositionX { get; set; }
        private List<int> historyPositionY { get; set; }
        private int platformp1 { get; set; }
        private int platformp2 { get; set; }
        #endregion

        #region Ctor
        public RocketLanding(int _x, int _y)
        {
            platformp1 = _x;
            platformp2 = _y;
            historyPositionX = new List<int>();
            historyPositionY = new List<int>();
        }
        #endregion

        #region Methods

        public async Task<string> LandingRocketAsync(int landX, int landY)
        {
            return await Task.Run(() =>
            {
                var isValidPlatForm = IsValidPlatForm(landX, landY);
                if (isValidPlatForm && HandleClashResult(landX, landY))
                    return  LandingResults.Clash;

                historyPositionX.Add(landX);
                historyPositionY.Add(landY);
                return isValidPlatForm ? LandingResults.OkForLanding : LandingResults.OutOfPlatform;
            });
        }

        public bool HandleClashResult(int landX, int landY)
        {
            var probX = IsValidatPrevX(landX);
            var probY = IsValidatPrevY(landY);
            return  (probX && probY)
                                || (historyPositionX.LastOrDefault() == landX
                                    && historyPositionY.LastOrDefault() == landY);
        }

        public bool IsValidPlatForm(int landX, int landY)
        {
            return landX < platformp1 
                   && landY < platformp2
                   && (landX >= 5 && landX <= 10)
                   && (landY >= 5 && landY <= 10);
        }
        public bool IsValidatPrevX(int landX)
        {
            return  historyPositionX.Select(x => x - 1).Contains(landX)
                      || historyPositionX.Select(x => x + 1).Contains(landX)
                        || historyPositionX.Select(x => x).Contains(landX);
        }
        public bool IsValidatPrevY(int landY)
        {
            return historyPositionY.Select(y => y - 1).Contains(landY)
                        || historyPositionY.Select(y => y + 1).Contains(landY)
                           || historyPositionY.Select(y => y).Contains(landY);
        }

        #endregion

    }



}
