namespace MonoTest.EnumTest
{
	using System.ComponentModel;

	// Token: 0x020007EC RID: 2028
	public enum Option
	{
		// Token: 0x040057EF RID: 22511
		INVALID,
		// Token: 0x040057F0 RID: 22512
		[Description("clientOptionsVersion")]
		CLIENT_OPTIONS_VERSION,
		// Token: 0x040057F1 RID: 22513
		[Description("sound")]
		SOUND,
		// Token: 0x040057F2 RID: 22514
		[Description("music")]
		MUSIC,
		// Token: 0x040057F3 RID: 22515
		[Description("cursor")]
		CURSOR,
		// Token: 0x040057F4 RID: 22516
		[Description("hud")]
		HUD,
		// Token: 0x040057F5 RID: 22517
		[Description("streaming")]
		STREAMING,
		// Token: 0x040057F6 RID: 22518
		[Description("soundvolume")]
		SOUND_VOLUME,
		// Token: 0x040057F7 RID: 22519
		[Description("musicvolume")]
		MUSIC_VOLUME,
		// Token: 0x040057F8 RID: 22520
		[Description("graphicswidth")]
		GFX_WIDTH,
		// Token: 0x040057F9 RID: 22521
		[Description("graphicsheight")]
		GFX_HEIGHT,
		// Token: 0x040057FA RID: 22522
		[Description("graphicsfullscreen")]
		GFX_FULLSCREEN,
		// Token: 0x040057FB RID: 22523
		[Description("hasseennewcinematic")]
		HAS_SEEN_NEW_CINEMATIC,
		// Token: 0x040057FC RID: 22524
		[Description("graphicsquality")]
		GFX_QUALITY,
		// Token: 0x040057FD RID: 22525
		[Description("fakepackopening")]
		FAKE_PACK_OPENING,
		// Token: 0x040057FE RID: 22526
		[Description("fakepackcount")]
		FAKE_PACK_COUNT,
		// Token: 0x040057FF RID: 22527
		[Description("healthygamingdebug")]
		HEALTHY_GAMING_DEBUG,
		// Token: 0x04005800 RID: 22528
		[Description("laststate")]
		LAST_SCENE_MODE,
		// Token: 0x04005801 RID: 22529
		[Description("locale")]
		LOCALE,
		// Token: 0x04005802 RID: 22530
		[Description("idlekicker")]
		IDLE_KICKER,
		// Token: 0x04005803 RID: 22531
		[Description("idlekicktime")]
		IDLE_KICK_TIME,
		// Token: 0x04005804 RID: 22532
		[Description("backgroundsound")]
		BACKGROUND_SOUND,
		// Token: 0x04005805 RID: 22533
		[Description("preferredregion")]
		PREFERRED_REGION,
		// Token: 0x04005806 RID: 22534
		[Description("forceShowIks")]
		FORCE_SHOW_IKS,
		// Token: 0x04005807 RID: 22535
		[Description("peguidebug")]
		PEGUI_DEBUG,
		// Token: 0x04005808 RID: 22536
		[Description("nearbyplayers2")]
		NEARBY_PLAYERS,
		// Token: 0x04005809 RID: 22537
		[Description("wincameraclear")]
		GFX_WIN_CAMERA_CLEAR,
		// Token: 0x0400580A RID: 22538
		[Description("msaa")]
		GFX_MSAA,
		// Token: 0x0400580B RID: 22539
		[Description("fxaa")]
		GFX_FXAA,
		// Token: 0x0400580C RID: 22540
		[Description("targetframerate")]
		GFX_TARGET_FRAME_RATE,
		// Token: 0x0400580D RID: 22541
		[Description("vsync")]
		GFX_VSYNC,
		// Token: 0x0400580E RID: 22542
		[Description("cardback")]
		CARD_BACK,
		// Token: 0x0400580F RID: 22543
		[Description("cardback2")]
		CARD_BACK2,
		// Token: 0x04005810 RID: 22544
		[Description("localtutorialprogress")]
		LOCAL_TUTORIAL_PROGRESS,
		// Token: 0x04005811 RID: 22545
		[Description("connecttobnet")]
		CONNECT_TO_AURORA,
		// Token: 0x04005812 RID: 22546
		[Description("reconnect")]
		RECONNECT,
		// Token: 0x04005813 RID: 22547
		[Description("reconnectTimeout")]
		RECONNECT_TIMEOUT,
		// Token: 0x04005814 RID: 22548
		[Description("reconnectRetryTime")]
		RECONNECT_RETRY_TIME,
		// Token: 0x04005815 RID: 22549
		[Description("changedcardsdata")]
		CHANGED_CARDS_DATA,
		// Token: 0x04005816 RID: 22550
		[Description("kelthuzadtaunts")]
		KELTHUZADTAUNTS,
		// Token: 0x04005817 RID: 22551
		[Description("winposx")]
		GFX_WIN_POSX,
		// Token: 0x04005818 RID: 22552
		[Description("winposy")]
		GFX_WIN_POSY,
		// Token: 0x04005819 RID: 22553
		[Description("preferredcdnindex")]
		PREFERRED_CDN_INDEX,
		// Token: 0x0400581A RID: 22554
		[Description("lastfaileddopversion")]
		LAST_FAILED_DOP_VERSION,
		// Token: 0x0400581B RID: 22555
		[Description("touchmode")]
		TOUCH_MODE,
		// Token: 0x0400581C RID: 22556
		[Description("gfxdevicewarning")]
		SHOWN_GFX_DEVICE_WARNING,
		// Token: 0x0400581D RID: 22557
		[Description("intro")]
		INTRO,
		// Token: 0x0400581E RID: 22558
		[Description("tutoriallostprogress")]
		TUTORIAL_LOST_PROGRESS,
		// Token: 0x0400581F RID: 22559
		[Description("errorScreen")]
		ERROR_SCREEN,
		// Token: 0x04005820 RID: 22560
		[Description("innkeepersSpecialViews")]
		WELCOME_QUEST_VIEWS,
		// Token: 0x04005821 RID: 22561
		[Description("innkeepersSpecialLastDownloadTime")]
		IKS_LAST_DOWNLOAD_TIME,
		// Token: 0x04005822 RID: 22562
		[Description("innkeepersSpecialLastResponse")]
		IKS_LAST_DOWNLOAD_RESPONSE,
		// Token: 0x04005823 RID: 22563
		[Description("innkeepersSpecialCacheAge")]
		IKS_CACHE_AGE,
		// Token: 0x04005824 RID: 22564
		[Description("cheatHistory")]
		CHEAT_HISTORY,
		// Token: 0x04005825 RID: 22565
		[Description("preloadCardAssets")]
		PRELOAD_CARD_ASSETS,
		// Token: 0x04005826 RID: 22566
		[Description("collectionPremiumType")]
		COLLECTION_PREMIUM_TYPE,
		// Token: 0x04005827 RID: 22567
		[Description("devTimescale")]
		DEV_TIMESCALE,
		// Token: 0x04005828 RID: 22568
		[Description("innkeepersSpecialLastShownAd")]
		IKS_LAST_SHOWN_AD,
		// Token: 0x04005829 RID: 22569
		[Description("seenPackProductList")]
		SEEN_PACK_PRODUCT_LIST,
		// Token: 0x0400582A RID: 22570
		[Description("showStandardOnly")]
		SHOW_STANDARD_ONLY,
		// Token: 0x0400582B RID: 22571
		[Description("showSetRotationIntroVisuals")]
		SHOW_SET_ROTATION_INTRO_VISUALS,
		// Token: 0x0400582C RID: 22572
		[Description("skipallmulligans")]
		SKIP_ALL_MULLIGANS,
		// Token: 0x0400582D RID: 22573
		[Description("isTemporaryAccountCheat")]
		IS_TEMPORARY_ACCOUNT_CHEAT,
		// Token: 0x0400582E RID: 22574
		[Description("temporaryAccountData")]
		TEMPORARY_ACCOUNT_DATA,
		// Token: 0x0400582F RID: 22575
		[Description("disallowedCloudStorage")]
		DISALLOWED_CLOUD_STORAGE,
		// Token: 0x04005830 RID: 22576
		[Description("createdAccount")]
		CREATED_ACCOUNT,
		// Token: 0x04005831 RID: 22577
		[Description("lastEventHealUpDate")]
		LAST_HEAL_UP_EVENT_DATE,
		// Token: 0x04005832 RID: 22578
		[Description("pushNotificationStatus")]
		PUSH_NOTIFICATION_STATUS,
		// Token: 0x04005833 RID: 22579
		[Description("dbfXmlLoading")]
		DBF_XML_LOADING,
		// Token: 0x04005834 RID: 22580
		[Description("hasShownDevicePerformanceWarning")]
		HAS_SHOWN_DEVICE_PERFORMANCE_WARNING,
		// Token: 0x04005835 RID: 22581
		[Description("screenshotDirectory")]
		SCREENSHOT_DIRECTORY,
		// Token: 0x04005836 RID: 22582
		[Description("simulatingCellular")]
		SIMULATE_CELLULAR,
		// Token: 0x04005837 RID: 22583
		[Description("assetDownloadEnabled")]
		ASSET_DOWNLOAD_ENABLED,
		// Token: 0x04005838 RID: 22584
		[Description("updateState")]
		UPDATE_STATE,
		// Token: 0x04005839 RID: 22585
		[Description("nativeUpdateState")]
		NATIVE_UPDATE_STATE,
		// Token: 0x0400583A RID: 22586
		[Description("AskUnknownApps")]
		ASK_UNKNOWN_APPS,
		// Token: 0x0400583B RID: 22587
		[Description("launchCount")]
		LAUNCH_COUNT,
		// Token: 0x0400583C RID: 22588
		[Description("isInstallReported")]
		IS_INSTALL_REPORTED,
		// Token: 0x0400583D RID: 22589
		[Description("firstInstallTime")]
		FIRST_INSTALL_TIME,
		// Token: 0x0400583E RID: 22590
		[Description("updatedClientVersion")]
		UPDATED_CLIENT_VERSION,
		// Token: 0x0400583F RID: 22591
		[Description("simulateNoInternet")]
		SIMULATE_NO_INTERNET,
		// Token: 0x04005840 RID: 22592
		[Description("updateStopLevel")]
		UPDATE_STOP_LEVEL,
		// Token: 0x04005841 RID: 22593
		[Description("maxDownloadSpeed")]
		MAX_DOWNLOAD_SPEED,
		// Token: 0x04005842 RID: 22594
		[Description("streamingSpeedInGame")]
		STREAMING_SPEED_IN_GAME,
		// Token: 0x04005843 RID: 22595
		[Description("autoConvertVirtualCurrency")]
		AUTOCONVERT_VIRTUAL_CURRENCY,
		// Token: 0x04005844 RID: 22596
		[Description("streamerMode")]
		STREAMER_MODE,
		// Token: 0x04005845 RID: 22597
		[Description("latestSeenShopProductList")]
		LATEST_SEEN_SHOP_PRODUCT_LIST,
		// Token: 0x04005846 RID: 22598
		[Description("latestDisplayedShopProductList")]
		LATEST_DISPLAYED_SHOP_PRODUCT_LIST,
		// Token: 0x04005847 RID: 22599
		[Description("rankDebug")]
		RANK_DEBUG,
		// Token: 0x04005848 RID: 22600
		[Description("debugCursor")]
		DEBUG_CURSOR,
		// Token: 0x04005849 RID: 22601
		[Description("crashCount")]
		CRASH_COUNT,
		// Token: 0x0400584A RID: 22602
		[Description("exceptionCount")]
		EXCEPTION_COUNT,
		// Token: 0x0400584B RID: 22603
		[Description("lowMemoryCount")]
		LOW_MEMORY_COUNT,
		// Token: 0x0400584C RID: 22604
		[Description("closedWithoutCrash")]
		CLOSED_WITHOUT_CRASH,
		// Token: 0x0400584D RID: 22605
		[Description("ExceptionHash")]
		EXCEPTION_HASH,
		// Token: 0x0400584E RID: 22606
		[Description("LastExceptionHash")]
		LAST_EXCEPTION_HASH,
		// Token: 0x0400584F RID: 22607
		[Description("CrashInARowCount")]
		CRASH_IN_A_ROW_COUNT,
		// Token: 0x04005850 RID: 22608
		[Description("SameExceptionCount")]
		SAME_EXCEPTION_COUNT,
		// Token: 0x04005851 RID: 22609
		[Description("CellPromptThreshold")]
		CELL_PROMPT_THRESHOLD,
		// Token: 0x04005852 RID: 22610
		[Description("DownloadAllFinished")]
		DOWNLOAD_ALL_FINISHED,
		// Token: 0x04005853 RID: 22611
		[Description("DelayedReporterStop")]
		DELAYED_REPORTER_STOP,
		// Token: 0x04005854 RID: 22612
		[Description("ScreenshakeEnabled")]
		SCREEN_SHAKE_ENABLED,
		// Token: 0x04005855 RID: 22613
		[Description("hudconfig")]
		HUD_CONFIG,
		// Token: 0x04005856 RID: 22614
		[Description("hudScale")]
		HUD_SCALE,
		// Token: 0x04005857 RID: 22615
		[Description("serverOptionsVersion")]
		SERVER_OPTIONS_VERSION,
		// Token: 0x04005858 RID: 22616
		[Description("pagemouseovers")]
		PAGE_MOUSE_OVERS,
		// Token: 0x04005859 RID: 22617
		[Description("covermouseovers")]
		COVER_MOUSE_OVERS,
		// Token: 0x0400585A RID: 22618
		[Description("aimode")]
		AI_MODE,
		// Token: 0x0400585B RID: 22619
		[Description("practicetipporgress")]
		TIP_PRACTICE_PROGRESS,
		// Token: 0x0400585C RID: 22620
		[Description("playtipprogress")]
		TIP_PLAY_PROGRESS,
		// Token: 0x0400585D RID: 22621
		[Description("forgetipprogress")]
		TIP_FORGE_PROGRESS,
		// Token: 0x0400585E RID: 22622
		[Description("lastChosenPreconHero")]
		LAST_PRECON_HERO_CHOSEN,
		// Token: 0x0400585F RID: 22623
		[Description("lastChosenCustomDeck")]
		LAST_CUSTOM_DECK_CHOSEN,
		// Token: 0x04005860 RID: 22624
		[Description("selectedAdventure")]
		SELECTED_ADVENTURE,
		// Token: 0x04005861 RID: 22625
		[Description("selectedAdventureMode")]
		SELECTED_ADVENTURE_MODE,
		// Token: 0x04005862 RID: 22626
		[Description("lastselectedbooster")]
		LAST_SELECTED_STORE_BOOSTER_ID,
		// Token: 0x04005863 RID: 22627
		[Description("lastselectedadventure")]
		LAST_SELECTED_STORE_ADVENTURE_ID,
		// Token: 0x04005864 RID: 22628
		[Description("lastselectedhero")]
		LAST_SELECTED_STORE_HERO_ID,
		// Token: 0x04005865 RID: 22629
		[Description("seenTB")]
		LATEST_SEEN_TAVERNBRAWL_SEASON,
		// Token: 0x04005866 RID: 22630
		[Description("seenTBScreen")]
		LATEST_SEEN_TAVERNBRAWL_SEASON_CHALKBOARD,
		// Token: 0x04005867 RID: 22631
		[Description("seenCrazyRulesQuote")]
		TIMES_SEEN_TAVERNBRAWL_CRAZY_RULES_QUOTE,
		// Token: 0x04005868 RID: 22632
		[Description("setRotationIntroProgress")]
		SET_ROTATION_INTRO_PROGRESS,
		// Token: 0x04005869 RID: 22633
		[Description("timesMousedOverSwitchFormatButton")]
		TIMES_MOUSED_OVER_SWITCH_FORMAT_BUTTON,
		// Token: 0x0400586A RID: 22634
		[Description("returningPlayerBannerSeen")]
		RETURNING_PLAYER_BANNER_SEEN,
		// Token: 0x0400586B RID: 22635
		[Description("seenTBSessionLimit")]
		LATEST_SEEN_TAVERNBRAWL_SESSION_LIMIT,
		// Token: 0x0400586C RID: 22636
		[Description("lastTavernJoined")]
		LAST_TAVERN_JOINED,
		// Token: 0x0400586D RID: 22637
		[Description("seenFSGB")]
		LATEST_SEEN_FIRESIDEBRAWL_SEASON,
		// Token: 0x0400586E RID: 22638
		[Description("seenFSGBScreen")]
		LATEST_SEEN_FIRESIDEBRAWL_SEASON_CHALKBOARD,
		// Token: 0x0400586F RID: 22639
		[Description("seenScheduledDoubleGoldVO")]
		LATEST_SEEN_SCHEDULED_DOUBLE_GOLD_VO,
		// Token: 0x04005870 RID: 22640
		[Description("seenScheduledAllPopupsShownVO")]
		LATEST_SEEN_SCHEDULED_ALL_POPUPS_SHOWN_VO,
		// Token: 0x04005871 RID: 22641
		[Description("seenScheduledEnteredArenaDraftVO")]
		LATEST_SEEN_SCHEDULED_ENTERED_ARENA_DRAFT,
		// Token: 0x04005872 RID: 22642
		[Description("seenScheduledLoginFlowComplete")]
		LATEST_SEEN_SCHEDULED_LOGIN_FLOW_COMPLETE,
		// Token: 0x04005873 RID: 22643
		[Description("seenWelcomeQuestDialog")]
		LATEST_SEEN_WELCOME_QUEST_DIALOG,
		// Token: 0x04005874 RID: 22644
		[Description("seenCurrencyChangeMessageForVersion")]
		LATEST_SEEN_CURRENCY_CHANGED_VERSION,
		// Token: 0x04005875 RID: 22645
		[Description("latestSeenAdventure")]
		LATEST_SEEN_ADVENTURE,
		// Token: 0x04005876 RID: 22646
		[Description("seenScheduledWelcomeQuestVO")]
		LATEST_SEEN_SCHEDULED_WELCOME_QUEST_SHOWN_VO,
		// Token: 0x04005877 RID: 22647
		[Description("seenScheduledGenericRewardShownVO")]
		LATEST_SEEN_SCHEDULED_GENERIC_REWARD_SHOWN_VO,
		// Token: 0x04005878 RID: 22648
		[Description("seenScheduledArenaRewardShownVO")]
		LATEST_SEEN_SCHEDULED_ARENA_REWARD_SHOWN_VO,
		// Token: 0x04005879 RID: 22649
		[Description("lastSelectedStorePackType")]
		LAST_SELECTED_STORE_PACK_TYPE,
		// Token: 0x0400587A RID: 22650
		[Description("whizbangPopupCounter")]
		WHIZBANG_POPUP_COUNTER,
		// Token: 0x0400587B RID: 22651
		[Description("setRotationIntroProgressNewPlayer")]
		SET_ROTATION_INTRO_PROGRESS_NEW_PLAYER,
		// Token: 0x0400587C RID: 22652
		[Description("hasclickedtournament")]
		HAS_CLICKED_TOURNAMENT,
		// Token: 0x0400587D RID: 22653
		[Description("hasopenedbooster")]
		HAS_OPENED_BOOSTER,
		// Token: 0x0400587E RID: 22654
		[Description("hasseentournament")]
		HAS_SEEN_TOURNAMENT,
		// Token: 0x0400587F RID: 22655
		[Description("hasseencollectionmanager")]
		HAS_SEEN_COLLECTIONMANAGER,
		// Token: 0x04005880 RID: 22656
		[Description("justfinishedtutorial")]
		JUST_FINISHED_TUTORIAL,
		// Token: 0x04005881 RID: 22657
		[Description("showadvancedcollectionmanager")]
		SHOW_ADVANCED_COLLECTIONMANAGER,
		// Token: 0x04005882 RID: 22658
		[Description("hasseenpracticetray")]
		HAS_SEEN_PRACTICE_TRAY,
		// Token: 0x04005883 RID: 22659
		[Description("firstHubVisitPastTutorial")]
		HAS_SEEN_HUB,
		// Token: 0x04005884 RID: 22660
		[Description("firstdeckcomplete")]
		HAS_FINISHED_A_DECK,
		// Token: 0x04005885 RID: 22661
		[Description("hasseenforge")]
		HAS_SEEN_FORGE,
		// Token: 0x04005886 RID: 22662
		[Description("hasseenforgeherochoice")]
		HAS_SEEN_FORGE_HERO_CHOICE,
		// Token: 0x04005887 RID: 22663
		[Description("hasseenforgecardchoice")]
		HAS_SEEN_FORGE_CARD_CHOICE,
		// Token: 0x04005888 RID: 22664
		[Description("hasseenforgecardchoice2")]
		HAS_SEEN_FORGE_CARD_CHOICE2,
		// Token: 0x04005889 RID: 22665
		[Description("hasseenforgeplaymode")]
		HAS_SEEN_FORGE_PLAY_MODE,
		// Token: 0x0400588A RID: 22666
		[Description("hasseenforge1win")]
		HAS_SEEN_FORGE_1WIN,
		// Token: 0x0400588B RID: 22667
		[Description("hasseenforge2loss")]
		HAS_SEEN_FORGE_2LOSS,
		// Token: 0x0400588C RID: 22668
		[Description("hasseenforgeretire")]
		HAS_SEEN_FORGE_RETIRE,
		// Token: 0x0400588D RID: 22669
		[Description("hasseenmulligan")]
		HAS_SEEN_MULLIGAN,
		// Token: 0x0400588E RID: 22670
		[Description("hasSeenExpertAI")]
		HAS_SEEN_EXPERT_AI,
		// Token: 0x0400588F RID: 22671
		[Description("hasSeenExpertAIUnlock")]
		HAS_SEEN_EXPERT_AI_UNLOCK,
		// Token: 0x04005890 RID: 22672
		[Description("hasseendeckhelper")]
		HAS_SEEN_DECK_HELPER,
		// Token: 0x04005891 RID: 22673
		[Description("hasSeenPackOpening")]
		HAS_SEEN_PACK_OPENING,
		// Token: 0x04005892 RID: 22674
		[Description("hasSeenPracticeMode")]
		HAS_SEEN_PRACTICE_MODE,
		// Token: 0x04005893 RID: 22675
		[Description("hasSeenCustomDeckPicker")]
		HAS_SEEN_CUSTOM_DECK_PICKER,
		// Token: 0x04005894 RID: 22676
		[Description("hasSeenAllBasicClassCardsComplete")]
		HAS_SEEN_ALL_BASIC_CLASS_CARDS_COMPLETE,
		// Token: 0x04005895 RID: 22677
		[Description("hasBeenNudgedToCM")]
		HAS_BEEN_NUDGED_TO_CM,
		// Token: 0x04005896 RID: 22678
		[Description("hasAddedCardsToDeck")]
		HAS_ADDED_CARDS_TO_DECK,
		// Token: 0x04005897 RID: 22679
		[Description("tipCraftingUnlocked")]
		TIP_CRAFTING_UNLOCKED,
		// Token: 0x04005898 RID: 22680
		[Description("hasPlayedExpertAI")]
		HAS_PLAYED_EXPERT_AI,
		// Token: 0x04005899 RID: 22681
		[Description("hasDisenchanted")]
		HAS_DISENCHANTED,
		// Token: 0x0400589A RID: 22682
		[Description("hasSeenShowAllCardsReminder")]
		HAS_SEEN_SHOW_ALL_CARDS_REMINDER,
		// Token: 0x0400589B RID: 22683
		[Description("hasSeenCraftingInstruction")]
		HAS_SEEN_CRAFTING_INSTRUCTION,
		// Token: 0x0400589C RID: 22684
		[Description("hasCrafted")]
		HAS_CRAFTED,
		// Token: 0x0400589D RID: 22685
		[Description("inRankedPlayMode")]
		IN_RANKED_PLAY_MODE,
		// Token: 0x0400589E RID: 22686
		[Description("hasSeenTheCoin")]
		HAS_SEEN_THE_COIN,
		// Token: 0x0400589F RID: 22687
		[Description("hasseen100goldReminder")]
		HAS_SEEN_100g_REMINDER,
		// Token: 0x040058A0 RID: 22688
		[Description("hasSeenGoldQtyInstruction")]
		HAS_SEEN_GOLD_QTY_INSTRUCTION,
		// Token: 0x040058A1 RID: 22689
		[Description("hasSeenLevel3")]
		HAS_SEEN_LEVEL_3,
		// Token: 0x040058A2 RID: 22690
		[Description("hasLostInArena")]
		HAS_LOST_IN_ARENA,
		// Token: 0x040058A3 RID: 22691
		[Description("hasRunOutOfQuests")]
		HAS_RUN_OUT_OF_QUESTS,
		// Token: 0x040058A4 RID: 22692
		[Description("hasAckedArenaRewards")]
		HAS_ACKED_ARENA_REWARDS,
		// Token: 0x040058A5 RID: 22693
		[Description("hasSeenStealthTaunter")]
		HAS_SEEN_STEALTH_TAUNTER,
		// Token: 0x040058A6 RID: 22694
		[Description("friendslistrequestsectionhide")]
		FRIENDS_LIST_REQUEST_SECTION_HIDE,
		// Token: 0x040058A7 RID: 22695
		[Description("friendslistcurrentgamesectionhide")]
		FRIENDS_LIST_CURRENTGAME_SECTION_HIDE,
		// Token: 0x040058A8 RID: 22696
		[Description("friendslistfriendsectionhide")]
		FRIENDS_LIST_FRIEND_SECTION_HIDE,
		// Token: 0x040058A9 RID: 22697
		[Description("friendslistnearbysectionhide")]
		FRIENDS_LIST_NEARBYPLAYER_SECTION_HIDE,
		// Token: 0x040058AA RID: 22698
		[Description("friendslistrecruitsectionhide")]
		FRIENDS_LIST_RECRUIT_SECTION_HIDE,
		// Token: 0x040058AB RID: 22699
		[Description("hasSeenHeroicWarning")]
		HAS_SEEN_HEROIC_WARNING,
		// Token: 0x040058AC RID: 22700
		[Description("hasSeenNaxx")]
		HAS_SEEN_NAXX,
		// Token: 0x040058AD RID: 22701
		[Description("hasEnteredNaxx")]
		HAS_ENTERED_NAXX,
		// Token: 0x040058AE RID: 22702
		[Description("hasSeenNaxxClassChallenge")]
		HAS_SEEN_NAXX_CLASS_CHALLENGE,
		// Token: 0x040058AF RID: 22703
		[Description("bundleJustPurchaseInHub")]
		BUNDLE_JUST_PURCHASE_IN_HUB,
		// Token: 0x040058B0 RID: 22704
		[Description("hasPlayedNaxx")]
		HAS_PLAYED_NAXX,
		// Token: 0x040058B1 RID: 22705
		[Description("spectatoropenjoin")]
		SPECTATOR_OPEN_JOIN,
		// Token: 0x040058B2 RID: 22706
		[Description("hasstartedadeck")]
		HAS_STARTED_A_DECK,
		// Token: 0x040058B3 RID: 22707
		[Description("hasseencollectionmanagerafterpractice")]
		HAS_SEEN_COLLECTIONMANAGER_AFTER_PRACTICE,
		// Token: 0x040058B4 RID: 22708
		[Description("hasSeenBRM")]
		HAS_SEEN_BRM,
		// Token: 0x040058B5 RID: 22709
		[Description("hasSeenLOE")]
		HAS_SEEN_LOE,
		// Token: 0x040058B6 RID: 22710
		[Description("hasClickedManaTab")]
		HAS_CLICKED_MANA_TAB,
		// Token: 0x040058B7 RID: 22711
		[Description("hasseenforgemaxwin")]
		HAS_SEEN_FORGE_MAX_WIN,
		// Token: 0x040058B8 RID: 22712
		[Description("hasheardtgtpackvo")]
		DEPRECATED_HAS_HEARD_TGT_PACK_VO,
		// Token: 0x040058B9 RID: 22713
		[Description("hasseenloestaffdisappear")]
		HAS_SEEN_LOE_STAFF_DISAPPEAR,
		// Token: 0x040058BA RID: 22714
		[Description("hasseenloestaffreappear")]
		HAS_SEEN_LOE_STAFF_REAPPEAR,
		// Token: 0x040058BB RID: 22715
		[Description("hasSeenUnlockAllHeroesTransition")]
		HAS_SEEN_UNLOCK_ALL_HEROES_TRANSITION,
		// Token: 0x040058BC RID: 22716
		[Description("createdFirstDeckForClass")]
		SKIP_DECK_TEMPLATE_PAGE_FOR_CLASS_FLAGS,
		// Token: 0x040058BD RID: 22717
		[Description("hasSeenDeckTemplateScreen")]
		HAS_SEEN_DECK_TEMPLATE_SCREEN,
		// Token: 0x040058BE RID: 22718
		[Description("hasClickedDeckTemplateReplace")]
		HAS_CLICKED_DECK_TEMPLATE_REPLACE,
		// Token: 0x040058BF RID: 22719
		[Description("hasSeenDeckTemplateGhostCard")]
		HAS_SEEN_DECK_TEMPLATE_GHOST_CARD,
		// Token: 0x040058C0 RID: 22720
		[Description("hasRemovedCardFromDeck")]
		HAS_REMOVED_CARD_FROM_DECK,
		// Token: 0x040058C1 RID: 22721
		[Description("hasSeenDeleteDeckReminder")]
		HAS_SEEN_DELETE_DECK_REMINDER,
		// Token: 0x040058C2 RID: 22722
		[Description("hasClickedCollectionButtonForNewCard")]
		HAS_CLICKED_COLLECTION_BUTTON_FOR_NEW_CARD,
		// Token: 0x040058C3 RID: 22723
		[Description("hasClickedCollectionButtonForNewDeck")]
		HAS_CLICKED_COLLECTION_BUTTON_FOR_NEW_DECK,
		// Token: 0x040058C4 RID: 22724
		[Description("inWildMode")]
		IN_WILD_MODE,
		// Token: 0x040058C5 RID: 22725
		[Description("hasSeenWildModeVO")]
		HAS_SEEN_WILD_MODE_VO,
		// Token: 0x040058C6 RID: 22726
		[Description("hasSeenStandardModeTutorial")]
		HAS_SEEN_STANDARD_MODE_TUTORIAL,
		// Token: 0x040058C7 RID: 22727
		[Description("needsToMakeStandardDeck")]
		NEEDS_TO_MAKE_STANDARD_DECK,
		// Token: 0x040058C8 RID: 22728
		[Description("hasSeenInvalidRotatedCard")]
		HAS_SEEN_INVALID_ROTATED_CARD,
		// Token: 0x040058C9 RID: 22729
		[Description("showSwitchToWildOnPlayScreen")]
		SHOW_SWITCH_TO_WILD_ON_PLAY_SCREEN,
		// Token: 0x040058CA RID: 22730
		[Description("showSwitchToWildOnCreateDeck")]
		SHOW_SWITCH_TO_WILD_ON_CREATE_DECK,
		// Token: 0x040058CB RID: 22731
		[Description("showWildDisclaimerPopupOnCreateDeck")]
		SHOW_WILD_DISCLAIMER_POPUP_ON_CREATE_DECK,
		// Token: 0x040058CC RID: 22732
		[Description("hasSeenBasicDeckWarning")]
		HAS_SEEN_BASIC_DECK_WARNING,
		// Token: 0x040058CD RID: 22733
		[Description("glowCollectionButtonAfterSetRotation")]
		GLOW_COLLECTION_BUTTON_AFTER_SET_ROTATION,
		// Token: 0x040058CE RID: 22734
		[Description("hasSeenSetFilterTutorial")]
		HAS_SEEN_SET_FILTER_TUTORIAL,
		// Token: 0x040058CF RID: 22735
		[Description("hasSeenRAF")]
		HAS_SEEN_RAF,
		// Token: 0x040058D0 RID: 22736
		[Description("hasSeenRAFRecruitURL")]
		HAS_SEEN_RAF_RECRUIT_URL,
		// Token: 0x040058D1 RID: 22737
		[Description("hasSeenKara")]
		HAS_SEEN_KARA,
		// Token: 0x040058D2 RID: 22738
		[Description("hasseenheroicbrawl")]
		HAS_SEEN_HEROIC_BRAWL,
		// Token: 0x040058D3 RID: 22739
		[Description("showInnkeeperDeckDialogue")]
		SHOW_INNKEEPER_DECK_DIALOGUE,
		// Token: 0x040058D4 RID: 22740
		[Description("hasHeardReturningPlayerWelcomeBackVO")]
		HAS_HEARD_RETURNING_PLAYER_WELCOME_BACK_VO,
		// Token: 0x040058D5 RID: 22741
		[Description("hasSeenReturningPlayerInnkeeperChallengeIntro")]
		HAS_SEEN_RETURNING_PLAYER_INNKEEPER_CHALLENGE_INTRO,
		// Token: 0x040058D6 RID: 22742
		[Description("hadItemThatWillBeRotatedInUpcomingEvent")]
		DEPRECATED_HAD_ITEM_THAT_WILL_BE_ROTATED_IN_UPCOMING_EVENT,
		// Token: 0x040058D7 RID: 22743
		[Description("shouldAutoCheckInToFiresideGatherings")]
		SHOULD_AUTO_CHECK_IN_TO_FIRESIDE_GATHERINGS,
		// Token: 0x040058D8 RID: 22744
		[Description("hasClickedFiresideBrawlButton")]
		HAS_CLICKED_FIRESIDE_BRAWL_BUTTON,
		// Token: 0x040058D9 RID: 22745
		[Description("hasClickedFiresideGatheringsButton")]
		HAS_CLICKED_FIRESIDE_GATHERINGS_BUTTON,
		// Token: 0x040058DA RID: 22746
		[Description("hasInitiatedFSGScan")]
		HAS_INITIATED_FIRESIDE_GATHERING_SCAN,
		// Token: 0x040058DB RID: 22747
		[Description("hasDisabledGoldensThisDraft")]
		HAS_DISABLED_GOLDENS_THIS_DRAFT,
		// Token: 0x040058DC RID: 22748
		[Description("hasSeenFreeArenaWinDialogThisDraft")]
		HAS_SEEN_FREE_ARENA_WIN_DIALOG_THIS_DRAFT,
		// Token: 0x040058DD RID: 22749
		[Description("hasSeenICC")]
		HAS_SEEN_ICC,
		// Token: 0x040058DE RID: 22750
		[Description("seenArenaSeasonStarting")]
		LATEST_SEEN_ARENA_SEASON_STARTING,
		// Token: 0x040058DF RID: 22751
		[Description("seenArenaSeasonEnding")]
		LATEST_SEEN_ARENA_SEASON_ENDING,
		// Token: 0x040058E0 RID: 22752
		[Description("hasSeenLOOT")]
		HAS_SEEN_LOOT,
		// Token: 0x040058E1 RID: 22753
		[Description("hasSeenLatestDungeonRunComplete")]
		HAS_SEEN_LATEST_DUNGEON_RUN_COMPLETE,
		// Token: 0x040058E2 RID: 22754
		[Description("hasSeenLOOTCharacterSelectVO")]
		HAS_SEEN_LOOT_CHARACTER_SELECT_VO,
		// Token: 0x040058E3 RID: 22755
		[Description("hasSeenLOOTWelcomeBannerVO")]
		HAS_SEEN_LOOT_WELCOME_BANNER_VO,
		// Token: 0x040058E4 RID: 22756
		[Description("hasSeenLOOTBossFlip1VO")]
		HAS_SEEN_LOOT_BOSS_FLIP_1_VO,
		// Token: 0x040058E5 RID: 22757
		[Description("hasSeenLOOTBossFlip2VO")]
		HAS_SEEN_LOOT_BOSS_FLIP_2_VO,
		// Token: 0x040058E6 RID: 22758
		[Description("hasSeenLOOTBossFlip3VO")]
		HAS_SEEN_LOOT_BOSS_FLIP_3_VO,
		// Token: 0x040058E7 RID: 22759
		[Description("hasSeenLOOTOfferTreasure1VO")]
		HAS_SEEN_LOOT_OFFER_TREASURE_1_VO,
		// Token: 0x040058E8 RID: 22760
		[Description("hasSeenLOOTOfferLootPacks1VO")]
		HAS_SEEN_LOOT_OFFER_LOOT_PACKS_1_VO,
		// Token: 0x040058E9 RID: 22761
		[Description("hasSeenLOOTOfferLootPacks2VO")]
		HAS_SEEN_LOOT_OFFER_LOOT_PACKS_2_VO,
		// Token: 0x040058EA RID: 22762
		[Description("hasJustSeenLOOTNoTakeCandleVO")]
		HAS_JUST_SEEN_LOOT_NO_TAKE_CANDLE_VO,
		// Token: 0x040058EB RID: 22763
		[Description("hasSeenLOOTInGameWinVO")]
		HAS_SEEN_LOOT_IN_GAME_WIN_VO,
		// Token: 0x040058EC RID: 22764
		[Description("hasSeenLOOTInGameLoseVO")]
		HAS_SEEN_LOOT_IN_GAME_LOSE_VO,
		// Token: 0x040058ED RID: 22765
		[Description("hasSeenLOOTInGameMulligan1VO")]
		HAS_SEEN_LOOT_IN_GAME_MULLIGAN_1_VO,
		// Token: 0x040058EE RID: 22766
		[Description("hasSeenLOOTInGameMulligan2VO")]
		HAS_SEEN_LOOT_IN_GAME_MULLIGAN_2_VO,
		// Token: 0x040058EF RID: 22767
		[Description("hasSeenLOOTCompleteAllClassesVO")]
		HAS_SEEN_LOOT_COMPLETE_ALL_CLASSES_VO,
		// Token: 0x040058F0 RID: 22768
		[Description("hasSeenLOOTBossHeroPower")]
		HAS_SEEN_LOOT_BOSS_HERO_POWER,
		// Token: 0x040058F1 RID: 22769
		[Description("hasSeenLOOTInGameLose2VO")]
		HAS_SEEN_LOOT_IN_GAME_LOSE_2_VO,
		// Token: 0x040058F2 RID: 22770
		[Description("hasSeenRankRevampEndOfGameWinsRequired")]
		HAS_SEEN_RANK_REVAMP_END_OF_GAME_WINS_REQUIRED,
		// Token: 0x040058F3 RID: 22771
		[Description("hasSeenGILBonusChallenge")]
		HAS_SEEN_GIL_BONUS_CHALLENGE,
		// Token: 0x040058F4 RID: 22772
		[Description("hasSeenPlayedTess")]
		HAS_SEEN_PLAYED_TESS,
		// Token: 0x040058F5 RID: 22773
		[Description("hasSeenPlayedDarius")]
		HAS_SEEN_PLAYED_DARIUS,
		// Token: 0x040058F6 RID: 22774
		[Description("hasSeenPlayedShaw")]
		HAS_SEEN_PLAYED_SHAW,
		// Token: 0x040058F7 RID: 22775
		[Description("hasSeenPlayedToki")]
		HAS_SEEN_PLAYED_TOKI,
		// Token: 0x040058F8 RID: 22776
		[Description("hasSeenBattlegroundsBoxButton")]
		HAS_SEEN_BATTLEGROUNDS_BOX_BUTTON
	}

}
