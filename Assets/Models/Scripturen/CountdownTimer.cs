using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
	private float countdownTimerStartTime;
	private int countdownTimerDuration;

	private float timeforIncreasingAlpha = 0;

	//-----------------------------
	public int GetTotalSeconds()
	{
		return countdownTimerDuration;
	}

	//-----------------------------
	public void ResetTimer(int seconds)
	{
		countdownTimerStartTime = Time.time;
		countdownTimerDuration = seconds;
	}

	//-----------------------------
	public int GetSecondsRemaining()
	{
		int elapsedSeconds = (int)(Time.time - countdownTimerStartTime);
		int secondsLeft = (countdownTimerDuration - elapsedSeconds);
		return secondsLeft;
	}

	//-----------------------------
	public float GetSecondsRemainingFloat()
	{
		float elapsedSeconds = (Time.time - countdownTimerStartTime);
		float secondsLeft = (countdownTimerDuration - elapsedSeconds);
		return secondsLeft;
	}

	//-----------------------------
	public float GetProportionTimeRemaining()
	{
		float proportionLeft = (float)GetSecondsRemainingFloat() / (float)GetTotalSeconds();
		return proportionLeft;
	}

	public float IncreaseAlpha()
	{

		if (timeforIncreasingAlpha < GetTotalSeconds())
		{
			float proportionLeft = timeforIncreasingAlpha / (float)GetTotalSeconds();
			timeforIncreasingAlpha += 1 * Time.deltaTime;
			return proportionLeft;
		}
		else
		{
			timeforIncreasingAlpha = 0;
			return 1.5f;
		}

	}

	//---------------------------------
	private string LeadingZero(int n)
	{
		// pad out numbers less than 10 with a leading 0
		// e.g. 1 becomes 01, 4 becomes 04 etc.
		return n.ToString().PadLeft(2, '0');
	}
}