using System;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class Language
{
    //several screens
    public string sections_menu;
    public string shop;
    public string yes;
    public string no;
    public string buy;
    public string get_for_free;
    public string thanks;
    public string back;

    //main screen
    public string options;
    public string play;
    public string developer;

    //sections screen
    public string main_screen;
    public string linear;
    public string power;
    public string root;
    public string logarithm;
    public string exponental;
    public string trigonometric;
    public string polinomial;
    public string hyperbolic;
    public string mixed;
    public string special;
    public string coming_soon;

    //game screen
    public string reset;
    public string run;
    public string completed;
    public string stars;
    public string buy_hint;
    public string tap_to_continue;
    public string tip1;
    public string tip2;
    public string tip3;
    public string tip4;
    public string tip5;
    public string hint;
    public string red_part_warning;

    //shop
    public string choose_ball;
    public string watch_ad_shop;
    public string not_enough_stars;
    public string congratilation_new_ball;
    public string congratilation_first_ball;
    public string ball_machine_help;
    public string balls;
    public string addons;
    public string addons_help;

    //options
    public string delete_progress;
    public string name_1;
    public string position_1;
    public string name_2;
    public string position_2;
    public string name_3;
    public string position_3;
    public string info;

    //rate game
    public string yeah;
    public string later;
    public string sure;
    public string not_really;
    public string rate_prompt_1;
    public string rate_prompt_yes;
    public string rate_prompt_no;

    //star shop
    public string add;
}


[XmlRoot("Language")]
public class LanguageXml
{
    //several screens
    [XmlElement("sections_menu")]
    public string sections_menu;
    [XmlElement("shop")]
    public string shop;
    [XmlElement("yes")]
    public string yes;
    [XmlElement("no")]
    public string no;
    [XmlElement("buy")]
    public string buy;
    [XmlElement("get_for_free")]
    public string get_for_free;
    [XmlElement("thanks")]
    public string thanks;
    [XmlElement("back")]
    public string back;

    //main screen
    [XmlElement("options")]
    public string options;
    [XmlElement("play")]
    public string play;
    [XmlElement("developer")]
    public string developer;

    //scenes screen
    [XmlElement("main_screen")]
    public string main_screen;
    [XmlElement("linear")]
    public string linear;
    [XmlElement("power")]
    public string power;
    [XmlElement("root")]
    public string root;
    [XmlElement("logarithm")]
    public string logarithm;
    [XmlElement("exponental")]
    public string exponental;
    [XmlElement("trigonometric")]
    public string trigonometric;
    [XmlElement("polinomial")]
    public string polinomial;
    [XmlElement("hyperbolic")]
    public string hyperbolic;
    [XmlElement("mixed")]
    public string mixed;
    [XmlElement("special")]
    public string special;

    //game screen
    [XmlElement("reset")]
    public string reset;
    [XmlElement("run")]
    public string run;
    [XmlElement("completed")]
    public string completed;
    [XmlElement("stars")]
    public string stars;
    [XmlElement("buy_hint")]
    public string buy_hint;
    [XmlElement("tap_to_continue")]
    public string tap_to_continue;
    [XmlElement("tip1")]
    public string tip1;
    [XmlElement("tip2")]
    public string tip2;
    [XmlElement("tip3")]
    public string tip3;
    [XmlElement("tip4")]
    public string tip4;
    [XmlElement("hint")]
    public string hint;
    [XmlElement("red_part_warning")]
    public string red_part_warning;

    //shop
    [XmlElement("choose_ball")]
    public string choose_ball;
    [XmlElement("watch_ad_shop")]
    public string watch_ad_shop;
    [XmlElement("not_enough_stars")]
    public string not_enough_stars;
    [XmlElement("congratilation_new_ball")]
    public string congratilation_new_ball;
    [XmlElement("congratilation_first_ball")]
    public string congratilation_first_ball;
    [XmlElement("ball_machine_help")]
    public string ball_machine_help;
    [XmlElement("balls")]
    public string balls;
    [XmlElement("addons")]
    public string addons;
    [XmlElement("addons_help")]
    public string addons_help;

    //options
    [XmlElement("delete_progress")]
    public string delete_progress;
    [XmlElement("name_1")]
    public string name_1;
    [XmlElement("position_1")]
    public string position_1;
    [XmlElement("name_2")]
    public string name_2;
    [XmlElement("position_2")]
    public string position_2;
    [XmlElement("name_3")]
    public string name_3;
    [XmlElement("position_3")]
    public string position_3;

    //rate game
    [XmlElement("yeah")]
    public string yeah;
    [XmlElement("later")]
    public string later;
    [XmlElement("sure")]
    public string sure;
    [XmlElement("not_really")]
    public string not_really;
    [XmlElement("rate_prompt_1")]
    public string rate_prompt_1;
    [XmlElement("rate_prompt_yes")]
    public string rate_prompt_yes;
    [XmlElement("rate_prompt_no")]
    public string rate_prompt_no;

    //star shop
    [XmlElement("add")]
    public string add;
}
