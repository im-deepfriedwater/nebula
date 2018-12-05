/**
 * Copyright (c) 2017 The Campfire Union Inc - All Rights Reserved.
 *
 * Licensed under the MIT license. See LICENSE file in the project root for
 * full license information.
 *
 * Email:   info@campfireunion.com
 * Website: https://www.campfireunion.com
 */

using UnityEngine;
using System.Collections;

namespace VRKeys {
	/// <summary>
	/// Base class for platform-specific inputs and controller access.
	/// </summary>
	public class Controller : MonoBehaviour {

		private void Start () {
		}

		public virtual void TriggerPulse () {
			// Override me!
		}

		public virtual bool OnGrip () {
			// Override me!
			return false;
		}
	}
}