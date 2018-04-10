using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GooglePlayController : MonoBehaviour{

    public static GooglePlayController instance = null;

    public UnityEngine.UI.Text AuthenticateText;

    void Awake() {
        instance = this;
    }

    void Start() {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        if (!PlayGamesPlatform.Instance.localUser.authenticated) {
            PlayGamesPlatform.Instance.Authenticate((bool success) => {
                if (success) {
                    AuthenticateText.text = "Log out";
                    achievements();
                } else {
                    AuthenticateText.text = "Log in";
                }
            }, true);
        } else {
            AuthenticateText.text = "Log out";
            achievements();
        }
    }

    public string getMail() {
        return !string.IsNullOrEmpty(((PlayGamesLocalUser)Social.localUser).Email) ? ((PlayGamesLocalUser)Social.localUser).Email : "unknown@erasofmankind.de";
    }

    public void login() {
        if (!Social.localUser.authenticated) {
            Social.localUser.Authenticate((bool success) => {
                if (success) {
                    AuthenticateText.text = "Log out";
                } else {
                    AuthenticateText.text = "Error, Try again";
                }
            });
        } else {
            ((PlayGamesPlatform)Social.Active).SignOut();
            AuthenticateText.text = "Log in";
        }
    }

    public void showAchievementsUI() {
        if (!Social.localUser.authenticated) {
            Social.localUser.Authenticate((bool success) => {
                if (success) {
                    Social.ShowAchievementsUI();
                    AuthenticateText.text = "Log out";
                } else {
                    AuthenticateText.text = "Log in";
                }
            });
        } else {
            Social.ShowAchievementsUI();
        }

    }

    public void showLeaderboardUI() {
        if (!Social.localUser.authenticated) {
            Social.localUser.Authenticate((bool success) => {
                if (success) {
                    PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_leaderboard);
                    AuthenticateText.text = "Log out";
                } else {
                    AuthenticateText.text = "Log in";
                }
            });
        } else {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_leaderboard);
        }
    }

    public void achievements() {
        StartCoroutine("Achievements");
    }

    private System.Collections.IEnumerator Achievements() {
        //Level
        for (int i = 0; i < Mathf.FloorToInt((float)(Data.CurrentLevel - 1) / CONSTANTS.LEVELS_PER_AGE); i++) {
            updateAchievement(CONSTANTS.LEVEL_ACHIEVEMENTS[i], 100.0f);
        }
        //Boni
        if (Data.Awesome >= 100) {
            updateAchievement(GPGSIds.achievement_awesome, 100.0f);
        }
        if (Data.Brave >= 100) {
            updateAchievement(GPGSIds.achievement_brave, 100.0f);
        }
        if (Data.Wisdom >= 100) {
            updateAchievement(GPGSIds.achievement_wisdom, 100.0f);
        }
        yield return null;
    }

    private void updateAchievement(string achievement, float percent) {
        Social.ReportProgress(achievement, percent, (bool success) => {
            if (success) {
                Debug.Log("Updated Achievement " + achievement + " to " + percent.ToString());
            } else {
                Debug.Log("ERROR updating Achievement " + achievement + " to " + percent.ToString());
            }
        });
    }

    private void incrementAchievement(string achievement, int steps) {
        PlayGamesPlatform.Instance.IncrementAchievement(achievement, steps, (bool success) => {
        if (success) {
            Debug.Log("Updated Achievement " + achievement + " to " + steps.ToString());
        } else {
            Debug.Log("ERROR updating Achievement " + achievement + " to " + steps.ToString());
        }
    });
    }

    public void updateLeaderboard(long points, string leaderboard) {
        Social.ReportScore(points, leaderboard, (bool success) => {
            if (success) {
                Debug.Log("Updated Leaderboard " + leaderboard + " to " + points.ToString());
            } else {
                Debug.Log("ERROR updating Leaderboard " + leaderboard + " to " + points.ToString());
            }
        });
    }
}
