using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEvent
{

    public class Fever : UnityEvent { }
    public static Fever OnFever = new Fever();
    public static void addOnFever(UnityAction callback) { OnFever.AddListener(callback); }
    public static void callOnFever() { if (OnFever != null) OnFever.Invoke(); }

    public class FeverEnd : UnityEvent { }
    public static FeverEnd OnFeverEnd = new FeverEnd();
    public static void addOnFeverEnd(UnityAction callback) { OnFeverEnd.AddListener(callback); }
    public static void callOnFeverEnd() { if (OnFeverEnd != null) OnFeverEnd.Invoke(); }

    public class Damage : UnityEvent { }
    public static Damage OnDamage = new Damage();
    public static void addOnDamage(UnityAction callback) { OnDamage.AddListener(callback); }
    public static void callOnDamage() { if (OnDamage != null) OnDamage.Invoke(); }

    public class Evasion : UnityEvent { }
    public static Evasion OnEvasion = new Evasion();
    public static void addOnEvasion(UnityAction callback) { OnEvasion.AddListener(callback); }
    public static void callOnEvasion() { if (OnEvasion != null) OnEvasion.Invoke(); }

}
