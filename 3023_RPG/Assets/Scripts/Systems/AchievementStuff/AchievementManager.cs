using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] AchievementPopup popupPrefab;
    [SerializeField] Canvas canvas;
    public static AchievementManager Instance { get; private set; }
    public static List<Achievement> achievements;
    public bool AchievementUnlocked(string achievementName)
    {
        bool result = false;

        if (achievements == null)
            return false;

        Achievement[] achievementsArray = achievements.ToArray();
        Achievement a = Array.Find(achievementsArray, ach => achievementName == ach.title);

        if (a == null)
            return false;

        result = a.achieved;

        return result;
    }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeAchievements();
    }

    private void InitializeAchievements()
    {
        if (achievements != null)
            return;

        achievements = new List<Achievement>();
        achievements.Add(new Achievement("Visited Field!", "Take a trip to the Field.", (object o) => LocationTracker.Instance.PlayerLocation == "Field"));
        achievements.Add(new Achievement("Visited Lake!", "Take a trip to the Lake.", (object o) => LocationTracker.Instance.PlayerLocation == "Lake"));
        achievements.Add(new Achievement("1 Play Coin", "Take 100 Steps in 1 Session.", (object o) => LocationTracker.Instance.StepsTaken >= 100));
        achievements.Add(new Achievement("2 Play Coins", "Take 200 Steps in 1 Session.", (object o) => LocationTracker.Instance.StepsTaken >= 200));
        //achievements.Add(new Achievement("Not So Precise", "Set your floating point to 230.5 or above.", (object o) => floating_point >= 230.5));
    }

    private void Update()
    {
        CheckAchievementCompletion();
    }

    private void CheckAchievementCompletion()
    {
        if (achievements == null)
            return;

        foreach (var achievement in achievements)
        {
            achievement.UpdateCompletion();
        }
    }

    public void DoPopup(string title, string description)
    {
        canvas = FindAnyObjectByType<Canvas>();
        AchievementPopup popup = Instantiate(popupPrefab, canvas.transform);
        popup.Popup(title, description);

    }
}

public class Achievement
{
    public Achievement(string title, string description, Predicate<object> requirement)
    {
        this.title = title;
        this.description = description;
        this.requirement = requirement;
    }

    public string title;
    public string description;
    public Predicate<object> requirement;

    public bool achieved;

    public void UpdateCompletion()
    {
        if (achieved)
            return;

        if (RequirementsMet())
        {
            Debug.Log($"{title}: {description}");
            achieved = true;
            AchievementManager.Instance.DoPopup(title, description);

        }
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }

    
}