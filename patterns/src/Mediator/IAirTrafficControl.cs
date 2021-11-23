using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator
{
    /// <summary>
    /// Mediator abstraction
    /// </summary>
    public interface IAirTrafficControl
    {
        void ReceiveAircraftLocation(Aircraft location);
        void RegisterAircraftUnderGuidance(Aircraft aircraft);
    }

    public class NewYorkTower : IAirTrafficControl
    {
        private readonly IList<Aircraft> _aircraftUnderGuidance = new List<Aircraft>();

        public void ReceiveAircraftLocation(Aircraft reportingAircraft)
        {
            foreach (var currentAircraftUnderGuidance in _aircraftUnderGuidance.
                Where(x => x != reportingAircraft))
            {
                if (Math.Abs(currentAircraftUnderGuidance.Altitude - reportingAircraft.Altitude) < 1000)
                {
                    reportingAircraft.Climb(1000);
                    //communicate to the class
                    currentAircraftUnderGuidance.WarnOfAirspaceIntrusionBy(reportingAircraft);
                }
            }
        }

        public void RegisterAircraftUnderGuidance(Aircraft aircraft)
        {
            if (!_aircraftUnderGuidance.Contains(aircraft))
            {
                _aircraftUnderGuidance.Add(aircraft);
            }
        }
    }
}
