using System.ComponentModel;


namespace MonoTest.EnumTest
{
	// Token: 0x020007EC RID: 2028
	public enum Option
	{
		// Token: 0x0400569C RID: 22172
		INVALID,
		// Token: 0x0400569D RID: 22173
		[Description("clientOptionsVersion")]
		CLIENT_OPTIONS_VERSION,
		// Token: 0x0400569E RID: 22174
		[Description("sound")]
		SOUND,
		// Token: 0x0400569F RID: 22175
		[Description("music")]
		MUSIC,
		// Token: 0x040056A0 RID: 22176
		[Description("cursor")]
		CURSOR,
		// Token: 0x040056A1 RID: 22177
		[Description("hud")]
		HUD,
		// Token: 0x040056A2 RID: 22178
		[Description("streaming")]
		STREAMING,
		// Token: 0x040056A3 RID: 22179
		[Description("soundvolume")]
		SOUND_VOLUME,
		// Token: 0x040056A4 RID: 22180
		[Description("musicvolume")]
		MUSIC_VOLUME,
		// Token: 0x040056A5 RID: 22181
		[Description("graphicswidth")]
		GFX_WIDTH,
		// Token: 0x040056A6 RID: 22182
		[Description("graphicsheight")]
		GFX_HEIGHT,
		// Token: 0x040056A7 RID: 22183
		[Description("graphicsfullscreen")]
		GFX_FULLSCREEN,
		// Token: 0x040056A8 RID: 22184
		[Description("hasseennewcinematic")]
		HAS_SEEN_NEW_CINEMATIC,
		// Token: 0x040056A9 RID: 22185
		[Description("graphicsquality")]
		GFX_QUALITY,
		// Token: 0x040056AA RID: 22186
		[Description("fakepackopening")]
		FAKE_PACK_OPENING,
		// Token: 0x040056AB RID: 22187
		[Description("fakepackcount")]
		FAKE_PACK_COUNT,
		// Token: 0x040056AC RID: 22188
		[Description("healthygamingdebug")]
		HEALTHY_GAMING_DEBUG,
		// Token: 0x040056AD RID: 22189
		[Description("laststate")]
		LAST_SCENE_MODE,
		// Token: 0x040056AE RID: 22190
		[Description("locale")]
		LOCALE,
		// Token: 0x040056AF RID: 22191
		[Description("idlekicker")]
		IDLE_KICKER,
		// Token: 0x040056B0 RID: 22192
		[Description("idlekicktime")]
		IDLE_KICK_TIME,
		// Token: 0x040056B1 RID: 22193
		[Description("backgroundsound")]
		BACKGROUND_SOUND,
		// Token: 0x040056B2 RID: 22194
		[Description("preferredregion")]
		PREFERRED_REGION,
		// Token: 0x040056B3 RID: 22195
		[Description("forceShowIks")]
		FORCE_SHOW_IKS,
		// Token: 0x040056B4 RID: 22196
		[Description("peguidebug")]
		PEGUI_DEBUG,
		// Token: 0x040056B5 RID: 22197
		[Description("nearbyplayers2")]
		NEARBY_PLAYERS,
		// Token: 0x040056B6 RID: 22198
		[Description("wincameraclear")]
		GFX_WIN_CAMERA_CLEAR,
		// Token: 0x040056B7 RID: 22199
		[Description("msaa")]
		GFX_MSAA,
		// Token: 0x040056B8 RID: 22200
		[Description("fxaa")]
		GFX_FXAA,
		// Token: 0x040056B9 RID: 22201
		[Description("targetframerate")]
		GFX_TARGET_FRAME_RATE,
		// Token: 0x040056BA RID: 22202
		[Description("vsync")]
		GFX_VSYNC,
		// Token: 0x040056BB RID: 22203
		[Description("cardback")]
		CARD_BACK,
		// Token: 0x040056BC RID: 22204
		[Description("cardback2")]
		CARD_BACK2,
		// Token: 0x040056BD RID: 22205
		[Description("localtutorialprogress")]
		LOCAL_TUTORIAL_PROGRESS,
		// Token: 0x040056BE RID: 22206
		[Description("connecttobnet")]
		CONNECT_TO_AURORA,
		// Token: 0x040056BF RID: 22207
		[Description("reconnect")]
		RECONNECT,
		// Token: 0x040056C0 RID: 22208
		[Description("reconnectTimeout")]
		RECONNECT_TIMEOUT,
		// Token: 0x040056C1 RID: 22209
		[Description("reconnectRetryTime")]
		RECONNECT_RETRY_TIME,
		// Token: 0x040056C2 RID: 22210
		[Description("changedcardsdata")]
		CHANGED_CARDS_DATA,
		// Token: 0x040056C3 RID: 22211
		[Description("kelthuzadtaunts")]
		KELTHUZADTAUNTS,
		// Token: 0x040056C4 RID: 22212
		[Description("winposx")]
		GFX_WIN_POSX,
		// Token: 0x040056C5 RID: 22213
		[Description("winposy")]
		GFX_WIN_POSY,
		// Token: 0x040056C6 RID: 22214
		[Description("preferredcdnindex")]
		PREFERRED_CDN_INDEX,
		// Token: 0x040056C7 RID: 22215
		[Description("lastfaileddopversion")]
		LAST_FAILED_DOP_VERSION,
		// Token: 0x040056C8 RID: 22216
		[Description("touchmode")]
		TOUCH_MODE,
		// Token: 0x040056C9 RID: 22217
		[Description("gfxdevicewarning")]
		SHOWN_GFX_DEVICE_WARNING,
		// Token: 0x040056CA RID: 22218
		[Description("intro")]
		INTRO,
		// Token: 0x040056CB RID: 22219
		[Description("tutoriallostprogress")]
		TUTORIAL_LOST_PROGRESS,
		// Token: 0x040056CC RID: 22220
		[Description("errorScreen")]
		ERROR_SCREEN,
		// Token: 0x040056CD RID: 22221
		[Description("innkeepersSpecialViews")]
		WELCOME_QUEST_VIEWS,
		// Token: 0x040056CE RID: 22222
		[Description("innkeepersSpecialLastDownloadTime")]
		IKS_LAST_DOWNLOAD_TIME,
		// Token: 0x040056CF RID: 22223
		[Description("innkeepersSpecialLastResponse")]
		IKS_LAST_DOWNLOAD_RESPONSE,
		// Token: 0x040056D0 RID: 22224
		[Description("innkeepersSpecialCacheAge")]
		IKS_CACHE_AGE,
		// Token: 0x040056D1 RID: 22225
		[Description("cheatHistory")]
		CHEAT_HISTORY,
		// Token: 0x040056D2 RID: 22226
		[Description("preloadCardAssets")]
		PRELOAD_CARD_ASSETS,
		// Token: 0x040056D3 RID: 22227
		[Description("collectionPremiumType")]
		COLLECTION_PREMIUM_TYPE,
		// Token: 0x040056D4 RID: 22228
		[Description("devTimescale")]
		DEV_TIMESCALE,
		// Token: 0x040056D5 RID: 22229
		[Description("innkeepersSpecialLastShownAd")]
		IKS_LAST_SHOWN_AD,
		// Token: 0x040056D6 RID: 22230
		[Description("seenPackProductList")]
		SEEN_PACK_PRODUCT_LIST,
		// Token: 0x040056D7 RID: 22231
		[Description("showStandardOnly")]
		SHOW_STANDARD_ONLY,
		// Token: 0x040056D8 RID: 22232
		[Description("showSetRotationIntroVisuals")]
		SHOW_SET_ROTATION_INTRO_VISUALS,
		// Token: 0x040056D9 RID: 22233
		[Description("skipallmulligans")]
		SKIP_ALL_MULLIGANS,
		// Token: 0x040056DA RID: 22234
		[Description("isTemporaryAccountCheat")]
		IS_TEMPORARY_ACCOUNT_CHEAT,
		// Token: 0x040056DB RID: 22235
		[Description("temporaryAccountData")]
		TEMPORARY_ACCOUNT_DATA,
		// Token: 0x040056DC RID: 22236
		[Description("disallowedCloudStorage")]
		DISALLOWED_CLOUD_STORAGE,
		// Token: 0x040056DD RID: 22237
		[Description("createdAccount")]
		CREATED_ACCOUNT,
		// Token: 0x040056DE RID: 22238
		[Description("lastEventHealUpDate")]
		LAST_HEAL_UP_EVENT_DATE,
		// Token: 0x040056DF RID: 22239
		[Description("pushNotificationStatus")]
		PUSH_NOTIFICATION_STATUS,
		// Token: 0x040056E0 RID: 22240
		[Description("dbfXmlLoading")]
		DBF_XML_LOADING,
		// Token: 0x040056E1 RID: 22241
		[Description("hasShownDevicePerformanceWarning")]
		HAS_SHOWN_DEVICE_PERFORMANCE_WARNING,
		// Token: 0x040056E2 RID: 22242
		[Description("screenshotDirectory")]
		SCREENSHOT_DIRECTORY,
		// Token: 0x040056E3 RID: 22243
		[Description("simulatingCellular")]
		SIMULATE_CELLULAR,
		// Token: 0x040056E4 RID: 22244
		[Description("assetDownloadEnabled")]
		ASSET_DOWNLOAD_ENABLED,
		// Token: 0x040056E5 RID: 22245
		[Description("updateState")]
		UPDATE_STATE,
		// Token: 0x040056E6 RID: 22246
		[Description("nativeUpdateState")]
		NATIVE_UPDATE_STATE,
		// Token: 0x040056E7 RID: 22247
		[Description("AskUnknownApps")]
		ASK_UNKNOWN_APPS,
		// Token: 0x040056E8 RID: 22248
		[Description("launchCount")]
		LAUNCH_COUNT,
		// Token: 0x040056E9 RID: 22249
		[Description("isInstallReported")]
		IS_INSTALL_REPORTED,
		// Token: 0x040056EA RID: 22250
		[Description("firstInstallTime")]
		FIRST_INSTALL_TIME,
		// Token: 0x040056EB RID: 22251
		[Description("updatedClientVersion")]
		UPDATED_CLIENT_VERSION,
		// Token: 0x040056EC RID: 22252
		[Description("simulateNoInternet")]
		SIMULATE_NO_INTERNET,
		// Token: 0x040056ED RID: 22253
		[Description("updateStopLevel")]
		UPDATE_STOP_LEVEL,
		// Token: 0x040056EE RID: 22254
		[Description("maxDownloadSpeed")]
		MAX_DOWNLOAD_SPEED,
		// Token: 0x040056EF RID: 22255
		[Description("streamingSpeedInGame")]
		STREAMING_SPEED_IN_GAME,
		// Token: 0x040056F0 RID: 22256
		[Description("autoConvertVirtualCurrency")]
		AUTOCONVERT_VIRTUAL_CURRENCY,
		// Token: 0x040056F1 RID: 22257
		[Description("streamerMode")]
		STREAMER_MODE,
		// Token: 0x040056F2 RID: 22258
		[Description("latestSeenShopProductList")]
		LATEST_SEEN_SHOP_PRODUCT_LIST,
		// Token: 0x040056F3 RID: 22259
		[Description("latestDisplayedShopProductList")]
		LATEST_DISPLAYED_SHOP_PRODUCT_LIST,
		// Token: 0x040056F4 RID: 22260
		[Description("rankDebug")]
		RANK_DEBUG,
		// Token: 0x040056F5 RID: 22261
		[Description("debugCursor")]
		DEBUG_CURSOR,
		// Token: 0x040056F6 RID: 22262
		[Description("crashCount")]
		CRASH_COUNT,
		// Token: 0x040056F7 RID: 22263
		[Description("exceptionCount")]
		EXCEPTION_COUNT,
		// Token: 0x040056F8 RID: 22264
		[Description("lowMemoryCount")]
		LOW_MEMORY_COUNT,
		// Token: 0x040056F9 RID: 22265
		[Description("closedWithoutCrash")]
		CLOSED_WITHOUT_CRASH,
		// Token: 0x040056FA RID: 22266
		[Description("ExceptionHash")]
		EXCEPTION_HASH,
		// Token: 0x040056FB RID: 22267
		[Description("LastExceptionHash")]
		LAST_EXCEPTION_HASH,
		// Token: 0x040056FC RID: 22268
		[Description("CrashInARowCount")]
		CRASH_IN_A_ROW_COUNT,
		// Token: 0x040056FD RID: 22269
		[Description("SameExceptionCount")]
		SAME_EXCEPTION_COUNT,
		// Token: 0x040056FE RID: 22270
		[Description("CellPromptThreshold")]
		CELL_PROMPT_THRESHOLD,
		// Token: 0x040056FF RID: 22271
		[Description("BaconLobbyEnabled")]
		BACON_LOBBY_ENABLED,
		// Token: 0x04005700 RID: 22272
		[Description("DownloadAllFinished")]
		DOWNLOAD_ALL_FINISHED,
		// Token: 0x04005701 RID: 22273
		[Description("DelayedReporterStop")]
		DELAYED_REPORTER_STOP,
		// Token: 0x04005702 RID: 22274
		[Description("LastReadTimeLog")]
		LAST_READ_TIME_LOG,
		// Token: 0x04005703 RID: 22275
		[Description("serverOptionsVersion")]
		SERVER_OPTIONS_VERSION,
		// Token: 0x04005704 RID: 22276
		[Description("pagemouseovers")]
		PAGE_MOUSE_OVERS,
		// Token: 0x04005705 RID: 22277
		[Description("covermouseovers")]
		COVER_MOUSE_OVERS,
		// Token: 0x04005706 RID: 22278
		[Description("aimode")]
		AI_MODE,
		// Token: 0x04005707 RID: 22279
		[Description("practicetipporgress")]
		TIP_PRACTICE_PROGRESS,
		// Token: 0x04005708 RID: 22280
		[Description("playtipprogress")]
		TIP_PLAY_PROGRESS,
		// Token: 0x04005709 RID: 22281
		[Description("forgetipprogress")]
		TIP_FORGE_PROGRESS,
		// Token: 0x0400570A RID: 22282
		[Description("lastChosenPreconHero")]
		LAST_PRECON_HERO_CHOSEN,
		// Token: 0x0400570B RID: 22283
		[Description("lastChosenCustomDeck")]
		LAST_CUSTOM_DECK_CHOSEN,
		// Token: 0x0400570C RID: 22284
		[Description("selectedAdventure")]
		SELECTED_ADVENTURE,
		// Token: 0x0400570D RID: 22285
		[Description("selectedAdventureMode")]
		SELECTED_ADVENTURE_MODE,
		// Token: 0x0400570E RID: 22286
		[Description("lastselectedbooster")]
		LAST_SELECTED_STORE_BOOSTER_ID,
		// Token: 0x0400570F RID: 22287
		[Description("lastselectedadventure")]
		LAST_SELECTED_STORE_ADVENTURE_ID,
		// Token: 0x04005710 RID: 22288
		[Description("lastselectedhero")]
		LAST_SELECTED_STORE_HERO_ID,
		// Token: 0x04005711 RID: 22289
		[Description("seenTB")]
		LATEST_SEEN_TAVERNBRAWL_SEASON,
		// Token: 0x04005712 RID: 22290
		[Description("seenTBScreen")]
		LATEST_SEEN_TAVERNBRAWL_SEASON_CHALKBOARD,
		// Token: 0x04005713 RID: 22291
		[Description("seenCrazyRulesQuote")]
		TIMES_SEEN_TAVERNBRAWL_CRAZY_RULES_QUOTE,
		// Token: 0x04005714 RID: 22292
		[Description("setRotationIntroProgress")]
		SET_ROTATION_INTRO_PROGRESS,
		// Token: 0x04005715 RID: 22293
		[Description("timesMousedOverSwitchFormatButton")]
		TIMES_MOUSED_OVER_SWITCH_FORMAT_BUTTON,
		// Token: 0x04005716 RID: 22294
		[Description("returningPlayerBannerSeen")]
		RETURNING_PLAYER_BANNER_SEEN,
		// Token: 0x04005717 RID: 22295
		[Description("seenTBSessionLimit")]
		LATEST_SEEN_TAVERNBRAWL_SESSION_LIMIT,
		// Token: 0x04005718 RID: 22296
		[Description("lastTavernJoined")]
		LAST_TAVERN_JOINED,
		// Token: 0x04005719 RID: 22297
		[Description("seenFSGB")]
		LATEST_SEEN_FIRESIDEBRAWL_SEASON,
		// Token: 0x0400571A RID: 22298
		[Description("seenFSGBScreen")]
		LATEST_SEEN_FIRESIDEBRAWL_SEASON_CHALKBOARD,
		// Token: 0x0400571B RID: 22299
		[Description("seenScheduledDoubleGoldVO")]
		LATEST_SEEN_SCHEDULED_DOUBLE_GOLD_VO,
		// Token: 0x0400571C RID: 22300
		[Description("seenScheduledAllPopupsShownVO")]
		LATEST_SEEN_SCHEDULED_ALL_POPUPS_SHOWN_VO,
		// Token: 0x0400571D RID: 22301
		[Description("seenScheduledEnteredArenaDraftVO")]
		LATEST_SEEN_SCHEDULED_ENTERED_ARENA_DRAFT,
		// Token: 0x0400571E RID: 22302
		[Description("seenScheduledLoginFlowComplete")]
		LATEST_SEEN_SCHEDULED_LOGIN_FLOW_COMPLETE,
		// Token: 0x0400571F RID: 22303
		[Description("seenWelcomeQuestDialog")]
		LATEST_SEEN_WELCOME_QUEST_DIALOG,
		// Token: 0x04005720 RID: 22304
		[Description("seenCurrencyChangeMessageForVersion")]
		LATEST_SEEN_CURRENCY_CHANGED_VERSION,
		// Token: 0x04005721 RID: 22305
		[Description("latestSeenAdventure")]
		LATEST_SEEN_ADVENTURE,
		// Token: 0x04005722 RID: 22306
		[Description("seenScheduledWelcomeQuestVO")]
		LATEST_SEEN_SCHEDULED_WELCOME_QUEST_SHOWN_VO,
		// Token: 0x04005723 RID: 22307
		[Description("seenScheduledGenericRewardShownVO")]
		LATEST_SEEN_SCHEDULED_GENERIC_REWARD_SHOWN_VO,
		// Token: 0x04005724 RID: 22308
		[Description("seenScheduledArenaRewardShownVO")]
		LATEST_SEEN_SCHEDULED_ARENA_REWARD_SHOWN_VO,
		// Token: 0x04005725 RID: 22309
		[Description("lastSelectedStorePackType")]
		LAST_SELECTED_STORE_PACK_TYPE,
		// Token: 0x04005726 RID: 22310
		[Description("whizbangPopupCounter")]
		WHIZBANG_POPUP_COUNTER,
		// Token: 0x04005727 RID: 22311
		[Description("setRotationIntroProgressNewPlayer")]
		SET_ROTATION_INTRO_PROGRESS_NEW_PLAYER,
		// Token: 0x04005728 RID: 22312
		[Description("hasclickedtournament")]
		HAS_CLICKED_TOURNAMENT,
		// Token: 0x04005729 RID: 22313
		[Description("hasopenedbooster")]
		HAS_OPENED_BOOSTER,
		// Token: 0x0400572A RID: 22314
		[Description("hasseentournament")]
		HAS_SEEN_TOURNAMENT,
		// Token: 0x0400572B RID: 22315
		[Description("hasseencollectionmanager")]
		HAS_SEEN_COLLECTIONMANAGER,
		// Token: 0x0400572C RID: 22316
		[Description("justfinishedtutorial")]
		JUST_FINISHED_TUTORIAL,
		// Token: 0x0400572D RID: 22317
		[Description("showadvancedcollectionmanager")]
		SHOW_ADVANCED_COLLECTIONMANAGER,
		// Token: 0x0400572E RID: 22318
		[Description("hasseenpracticetray")]
		HAS_SEEN_PRACTICE_TRAY,
		// Token: 0x0400572F RID: 22319
		[Description("firstHubVisitPastTutorial")]
		HAS_SEEN_HUB,
		// Token: 0x04005730 RID: 22320
		[Description("firstdeckcomplete")]
		HAS_FINISHED_A_DECK,
		// Token: 0x04005731 RID: 22321
		[Description("hasseenforge")]
		HAS_SEEN_FORGE,
		// Token: 0x04005732 RID: 22322
		[Description("hasseenforgeherochoice")]
		HAS_SEEN_FORGE_HERO_CHOICE,
		// Token: 0x04005733 RID: 22323
		[Description("hasseenforgecardchoice")]
		HAS_SEEN_FORGE_CARD_CHOICE,
		// Token: 0x04005734 RID: 22324
		[Description("hasseenforgecardchoice2")]
		HAS_SEEN_FORGE_CARD_CHOICE2,
		// Token: 0x04005735 RID: 22325
		[Description("hasseenforgeplaymode")]
		HAS_SEEN_FORGE_PLAY_MODE,
		// Token: 0x04005736 RID: 22326
		[Description("hasseenforge1win")]
		HAS_SEEN_FORGE_1WIN,
		// Token: 0x04005737 RID: 22327
		[Description("hasseenforge2loss")]
		HAS_SEEN_FORGE_2LOSS,
		// Token: 0x04005738 RID: 22328
		[Description("hasseenforgeretire")]
		HAS_SEEN_FORGE_RETIRE,
		// Token: 0x04005739 RID: 22329
		[Description("hasseenmulligan")]
		HAS_SEEN_MULLIGAN,
		// Token: 0x0400573A RID: 22330
		[Description("hasSeenExpertAI")]
		HAS_SEEN_EXPERT_AI,
		// Token: 0x0400573B RID: 22331
		[Description("hasSeenExpertAIUnlock")]
		HAS_SEEN_EXPERT_AI_UNLOCK,
		// Token: 0x0400573C RID: 22332
		[Description("hasseendeckhelper")]
		HAS_SEEN_DECK_HELPER,
		// Token: 0x0400573D RID: 22333
		[Description("hasSeenPackOpening")]
		HAS_SEEN_PACK_OPENING,
		// Token: 0x0400573E RID: 22334
		[Description("hasSeenPracticeMode")]
		HAS_SEEN_PRACTICE_MODE,
		// Token: 0x0400573F RID: 22335
		[Description("hasSeenCustomDeckPicker")]
		HAS_SEEN_CUSTOM_DECK_PICKER,
		// Token: 0x04005740 RID: 22336
		[Description("hasSeenAllBasicClassCardsComplete")]
		HAS_SEEN_ALL_BASIC_CLASS_CARDS_COMPLETE,
		// Token: 0x04005741 RID: 22337
		[Description("hasBeenNudgedToCM")]
		HAS_BEEN_NUDGED_TO_CM,
		// Token: 0x04005742 RID: 22338
		[Description("hasAddedCardsToDeck")]
		HAS_ADDED_CARDS_TO_DECK,
		// Token: 0x04005743 RID: 22339
		[Description("tipCraftingUnlocked")]
		TIP_CRAFTING_UNLOCKED,
		// Token: 0x04005744 RID: 22340
		[Description("hasPlayedExpertAI")]
		HAS_PLAYED_EXPERT_AI,
		// Token: 0x04005745 RID: 22341
		[Description("hasDisenchanted")]
		HAS_DISENCHANTED,
		// Token: 0x04005746 RID: 22342
		[Description("hasSeenShowAllCardsReminder")]
		HAS_SEEN_SHOW_ALL_CARDS_REMINDER,
		// Token: 0x04005747 RID: 22343
		[Description("hasSeenCraftingInstruction")]
		HAS_SEEN_CRAFTING_INSTRUCTION,
		// Token: 0x04005748 RID: 22344
		[Description("hasCrafted")]
		HAS_CRAFTED,
		// Token: 0x04005749 RID: 22345
		[Description("inRankedPlayMode")]
		IN_RANKED_PLAY_MODE,
		// Token: 0x0400574A RID: 22346
		[Description("hasSeenTheCoin")]
		HAS_SEEN_THE_COIN,
		// Token: 0x0400574B RID: 22347
		[Description("hasseen100goldReminder")]
		HAS_SEEN_100g_REMINDER,
		// Token: 0x0400574C RID: 22348
		[Description("hasSeenGoldQtyInstruction")]
		HAS_SEEN_GOLD_QTY_INSTRUCTION,
		// Token: 0x0400574D RID: 22349
		[Description("hasSeenLevel3")]
		HAS_SEEN_LEVEL_3,
		// Token: 0x0400574E RID: 22350
		[Description("hasLostInArena")]
		HAS_LOST_IN_ARENA,
		// Token: 0x0400574F RID: 22351
		[Description("hasRunOutOfQuests")]
		HAS_RUN_OUT_OF_QUESTS,
		// Token: 0x04005750 RID: 22352
		[Description("hasAckedArenaRewards")]
		HAS_ACKED_ARENA_REWARDS,
		// Token: 0x04005751 RID: 22353
		[Description("hasSeenStealthTaunter")]
		HAS_SEEN_STEALTH_TAUNTER,
		// Token: 0x04005752 RID: 22354
		[Description("friendslistrequestsectionhide")]
		FRIENDS_LIST_REQUEST_SECTION_HIDE,
		// Token: 0x04005753 RID: 22355
		[Description("friendslistcurrentgamesectionhide")]
		FRIENDS_LIST_CURRENTGAME_SECTION_HIDE,
		// Token: 0x04005754 RID: 22356
		[Description("friendslistfriendsectionhide")]
		FRIENDS_LIST_FRIEND_SECTION_HIDE,
		// Token: 0x04005755 RID: 22357
		[Description("friendslistnearbysectionhide")]
		FRIENDS_LIST_NEARBYPLAYER_SECTION_HIDE,
		// Token: 0x04005756 RID: 22358
		[Description("friendslistrecruitsectionhide")]
		FRIENDS_LIST_RECRUIT_SECTION_HIDE,
		// Token: 0x04005757 RID: 22359
		[Description("hasSeenHeroicWarning")]
		HAS_SEEN_HEROIC_WARNING,
		// Token: 0x04005758 RID: 22360
		[Description("hasSeenNaxx")]
		HAS_SEEN_NAXX,
		// Token: 0x04005759 RID: 22361
		[Description("hasEnteredNaxx")]
		HAS_ENTERED_NAXX,
		// Token: 0x0400575A RID: 22362
		[Description("hasSeenNaxxClassChallenge")]
		HAS_SEEN_NAXX_CLASS_CHALLENGE,
		// Token: 0x0400575B RID: 22363
		[Description("bundleJustPurchaseInHub")]
		BUNDLE_JUST_PURCHASE_IN_HUB,
		// Token: 0x0400575C RID: 22364
		[Description("hasPlayedNaxx")]
		HAS_PLAYED_NAXX,
		// Token: 0x0400575D RID: 22365
		[Description("spectatoropenjoin")]
		SPECTATOR_OPEN_JOIN,
		// Token: 0x0400575E RID: 22366
		[Description("hasstartedadeck")]
		HAS_STARTED_A_DECK,
		// Token: 0x0400575F RID: 22367
		[Description("hasseencollectionmanagerafterpractice")]
		HAS_SEEN_COLLECTIONMANAGER_AFTER_PRACTICE,
		// Token: 0x04005760 RID: 22368
		[Description("hasSeenBRM")]
		HAS_SEEN_BRM,
		// Token: 0x04005761 RID: 22369
		[Description("hasSeenLOE")]
		HAS_SEEN_LOE,
		// Token: 0x04005762 RID: 22370
		[Description("hasClickedManaTab")]
		HAS_CLICKED_MANA_TAB,
		// Token: 0x04005763 RID: 22371
		[Description("hasseenforgemaxwin")]
		HAS_SEEN_FORGE_MAX_WIN,
		// Token: 0x04005764 RID: 22372
		[Description("hasheardtgtpackvo")]
		DEPRECATED_HAS_HEARD_TGT_PACK_VO,
		// Token: 0x04005765 RID: 22373
		[Description("hasseenloestaffdisappear")]
		HAS_SEEN_LOE_STAFF_DISAPPEAR,
		// Token: 0x04005766 RID: 22374
		[Description("hasseenloestaffreappear")]
		HAS_SEEN_LOE_STAFF_REAPPEAR,
		// Token: 0x04005767 RID: 22375
		[Description("hasSeenUnlockAllHeroesTransition")]
		HAS_SEEN_UNLOCK_ALL_HEROES_TRANSITION,
		// Token: 0x04005768 RID: 22376
		[Description("createdFirstDeckForClass")]
		SKIP_DECK_TEMPLATE_PAGE_FOR_CLASS_FLAGS,
		// Token: 0x04005769 RID: 22377
		[Description("hasSeenDeckTemplateScreen")]
		HAS_SEEN_DECK_TEMPLATE_SCREEN,
		// Token: 0x0400576A RID: 22378
		[Description("hasClickedDeckTemplateReplace")]
		HAS_CLICKED_DECK_TEMPLATE_REPLACE,
		// Token: 0x0400576B RID: 22379
		[Description("hasSeenDeckTemplateGhostCard")]
		HAS_SEEN_DECK_TEMPLATE_GHOST_CARD,
		// Token: 0x0400576C RID: 22380
		[Description("hasRemovedCardFromDeck")]
		HAS_REMOVED_CARD_FROM_DECK,
		// Token: 0x0400576D RID: 22381
		[Description("hasSeenDeleteDeckReminder")]
		HAS_SEEN_DELETE_DECK_REMINDER,
		// Token: 0x0400576E RID: 22382
		[Description("hasClickedCollectionButtonForNewCard")]
		HAS_CLICKED_COLLECTION_BUTTON_FOR_NEW_CARD,
		// Token: 0x0400576F RID: 22383
		[Description("hasClickedCollectionButtonForNewDeck")]
		HAS_CLICKED_COLLECTION_BUTTON_FOR_NEW_DECK,
		// Token: 0x04005770 RID: 22384
		[Description("inWildMode")]
		IN_WILD_MODE,
		// Token: 0x04005771 RID: 22385
		[Description("hasSeenWildModeVO")]
		HAS_SEEN_WILD_MODE_VO,
		// Token: 0x04005772 RID: 22386
		[Description("hasSeenStandardModeTutorial")]
		HAS_SEEN_STANDARD_MODE_TUTORIAL,
		// Token: 0x04005773 RID: 22387
		[Description("needsToMakeStandardDeck")]
		NEEDS_TO_MAKE_STANDARD_DECK,
		// Token: 0x04005774 RID: 22388
		[Description("hasSeenInvalidRotatedCard")]
		HAS_SEEN_INVALID_ROTATED_CARD,
		// Token: 0x04005775 RID: 22389
		[Description("showSwitchToWildOnPlayScreen")]
		SHOW_SWITCH_TO_WILD_ON_PLAY_SCREEN,
		// Token: 0x04005776 RID: 22390
		[Description("showSwitchToWildOnCreateDeck")]
		SHOW_SWITCH_TO_WILD_ON_CREATE_DECK,
		// Token: 0x04005777 RID: 22391
		[Description("showWildDisclaimerPopupOnCreateDeck")]
		SHOW_WILD_DISCLAIMER_POPUP_ON_CREATE_DECK,
		// Token: 0x04005778 RID: 22392
		[Description("hasSeenBasicDeckWarning")]
		HAS_SEEN_BASIC_DECK_WARNING,
		// Token: 0x04005779 RID: 22393
		[Description("glowCollectionButtonAfterSetRotation")]
		GLOW_COLLECTION_BUTTON_AFTER_SET_ROTATION,
		// Token: 0x0400577A RID: 22394
		[Description("hasSeenSetFilterTutorial")]
		HAS_SEEN_SET_FILTER_TUTORIAL,
		// Token: 0x0400577B RID: 22395
		[Description("hasSeenRAF")]
		HAS_SEEN_RAF,
		// Token: 0x0400577C RID: 22396
		[Description("hasSeenRAFRecruitURL")]
		HAS_SEEN_RAF_RECRUIT_URL,
		// Token: 0x0400577D RID: 22397
		[Description("hasSeenKara")]
		HAS_SEEN_KARA,
		// Token: 0x0400577E RID: 22398
		[Description("hasseenheroicbrawl")]
		HAS_SEEN_HEROIC_BRAWL,
		// Token: 0x0400577F RID: 22399
		[Description("showInnkeeperDeckDialogue")]
		SHOW_INNKEEPER_DECK_DIALOGUE,
		// Token: 0x04005780 RID: 22400
		[Description("hasHeardReturningPlayerWelcomeBackVO")]
		HAS_HEARD_RETURNING_PLAYER_WELCOME_BACK_VO,
		// Token: 0x04005781 RID: 22401
		[Description("hasSeenReturningPlayerInnkeeperChallengeIntro")]
		HAS_SEEN_RETURNING_PLAYER_INNKEEPER_CHALLENGE_INTRO,
		// Token: 0x04005782 RID: 22402
		[Description("hadItemThatWillBeRotatedInUpcomingEvent")]
		DEPRECATED_HAD_ITEM_THAT_WILL_BE_ROTATED_IN_UPCOMING_EVENT,
		// Token: 0x04005783 RID: 22403
		[Description("shouldAutoCheckInToFiresideGatherings")]
		SHOULD_AUTO_CHECK_IN_TO_FIRESIDE_GATHERINGS,
		// Token: 0x04005784 RID: 22404
		[Description("hasClickedFiresideBrawlButton")]
		HAS_CLICKED_FIRESIDE_BRAWL_BUTTON,
		// Token: 0x04005785 RID: 22405
		[Description("hasClickedFiresideGatheringsButton")]
		HAS_CLICKED_FIRESIDE_GATHERINGS_BUTTON,
		// Token: 0x04005786 RID: 22406
		[Description("hasInitiatedFSGScan")]
		HAS_INITIATED_FIRESIDE_GATHERING_SCAN,
		// Token: 0x04005787 RID: 22407
		[Description("hasDisabledGoldensThisDraft")]
		HAS_DISABLED_GOLDENS_THIS_DRAFT,
		// Token: 0x04005788 RID: 22408
		[Description("hasSeenFreeArenaWinDialogThisDraft")]
		HAS_SEEN_FREE_ARENA_WIN_DIALOG_THIS_DRAFT,
		// Token: 0x04005789 RID: 22409
		[Description("hasSeenICC")]
		HAS_SEEN_ICC,
		// Token: 0x0400578A RID: 22410
		[Description("seenArenaSeasonStarting")]
		LATEST_SEEN_ARENA_SEASON_STARTING,
		// Token: 0x0400578B RID: 22411
		[Description("seenArenaSeasonEnding")]
		LATEST_SEEN_ARENA_SEASON_ENDING,
		// Token: 0x0400578C RID: 22412
		[Description("hasSeenLOOT")]
		HAS_SEEN_LOOT,
		// Token: 0x0400578D RID: 22413
		[Description("hasSeenLatestDungeonRunComplete")]
		HAS_SEEN_LATEST_DUNGEON_RUN_COMPLETE,
		// Token: 0x0400578E RID: 22414
		[Description("hasSeenLOOTCharacterSelectVO")]
		HAS_SEEN_LOOT_CHARACTER_SELECT_VO,
		// Token: 0x0400578F RID: 22415
		[Description("hasSeenLOOTWelcomeBannerVO")]
		HAS_SEEN_LOOT_WELCOME_BANNER_VO,
		// Token: 0x04005790 RID: 22416
		[Description("hasSeenLOOTBossFlip1VO")]
		HAS_SEEN_LOOT_BOSS_FLIP_1_VO,
		// Token: 0x04005791 RID: 22417
		[Description("hasSeenLOOTBossFlip2VO")]
		HAS_SEEN_LOOT_BOSS_FLIP_2_VO,
		// Token: 0x04005792 RID: 22418
		[Description("hasSeenLOOTBossFlip3VO")]
		HAS_SEEN_LOOT_BOSS_FLIP_3_VO,
		// Token: 0x04005793 RID: 22419
		[Description("hasSeenLOOTOfferTreasure1VO")]
		HAS_SEEN_LOOT_OFFER_TREASURE_1_VO,
		// Token: 0x04005794 RID: 22420
		[Description("hasSeenLOOTOfferLootPacks1VO")]
		HAS_SEEN_LOOT_OFFER_LOOT_PACKS_1_VO,
		// Token: 0x04005795 RID: 22421
		[Description("hasSeenLOOTOfferLootPacks2VO")]
		HAS_SEEN_LOOT_OFFER_LOOT_PACKS_2_VO,
		// Token: 0x04005796 RID: 22422
		[Description("hasJustSeenLOOTNoTakeCandleVO")]
		HAS_JUST_SEEN_LOOT_NO_TAKE_CANDLE_VO,
		// Token: 0x04005797 RID: 22423
		[Description("hasSeenLOOTInGameWinVO")]
		HAS_SEEN_LOOT_IN_GAME_WIN_VO,
		// Token: 0x04005798 RID: 22424
		[Description("hasSeenLOOTInGameLoseVO")]
		HAS_SEEN_LOOT_IN_GAME_LOSE_VO,
		// Token: 0x04005799 RID: 22425
		[Description("hasSeenLOOTInGameMulligan1VO")]
		HAS_SEEN_LOOT_IN_GAME_MULLIGAN_1_VO,
		// Token: 0x0400579A RID: 22426
		[Description("hasSeenLOOTInGameMulligan2VO")]
		HAS_SEEN_LOOT_IN_GAME_MULLIGAN_2_VO,
		// Token: 0x0400579B RID: 22427
		[Description("hasSeenLOOTCompleteAllClassesVO")]
		HAS_SEEN_LOOT_COMPLETE_ALL_CLASSES_VO,
		// Token: 0x0400579C RID: 22428
		[Description("hasSeenLOOTBossHeroPower")]
		HAS_SEEN_LOOT_BOSS_HERO_POWER,
		// Token: 0x0400579D RID: 22429
		[Description("hasSeenLOOTInGameLose2VO")]
		HAS_SEEN_LOOT_IN_GAME_LOSE_2_VO,
		// Token: 0x0400579E RID: 22430
		[Description("hasSeenRankRevampEndOfGameWinsRequired")]
		HAS_SEEN_RANK_REVAMP_END_OF_GAME_WINS_REQUIRED,
		// Token: 0x0400579F RID: 22431
		[Description("hasSeenGILBonusChallenge")]
		HAS_SEEN_GIL_BONUS_CHALLENGE,
		// Token: 0x040057A0 RID: 22432
		[Description("hasSeenPlayedTess")]
		HAS_SEEN_PLAYED_TESS,
		// Token: 0x040057A1 RID: 22433
		[Description("hasSeenPlayedDarius")]
		HAS_SEEN_PLAYED_DARIUS,
		// Token: 0x040057A2 RID: 22434
		[Description("hasSeenPlayedShaw")]
		HAS_SEEN_PLAYED_SHAW,
		// Token: 0x040057A3 RID: 22435
		[Description("hasSeenPlayedToki")]
		HAS_SEEN_PLAYED_TOKI,
		// Token: 0x040057A4 RID: 22436
		[Description("hasSeenBattlegroundsBoxButton")]
		HAS_SEEN_BATTLEGROUNDS_BOX_BUTTON
	}

}
