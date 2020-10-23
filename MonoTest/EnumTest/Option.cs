namespace MonoTest.EnumTest
{
	using System;
	using System.ComponentModel;

	// Token: 0x0200083B RID: 2107
	public enum Option
	{
		// Token: 0x04005A04 RID: 23044
		INVALID,
		// Token: 0x04005A05 RID: 23045
		[Description("clientOptionsVersion")]
		CLIENT_OPTIONS_VERSION,
		// Token: 0x04005A06 RID: 23046
		[Description("sound")]
		SOUND,
		// Token: 0x04005A07 RID: 23047
		[Description("music")]
		MUSIC,
		// Token: 0x04005A08 RID: 23048
		[Description("cursor")]
		CURSOR,
		// Token: 0x04005A09 RID: 23049
		[Description("hud")]
		HUD,
		// Token: 0x04005A0A RID: 23050
		[Description("streaming")]
		STREAMING,
		// Token: 0x04005A0B RID: 23051
		[Description("soundvolume")]
		SOUND_VOLUME,
		// Token: 0x04005A0C RID: 23052
		[Description("musicvolume")]
		MUSIC_VOLUME,
		// Token: 0x04005A0D RID: 23053
		[Description("graphicswidth")]
		GFX_WIDTH,
		// Token: 0x04005A0E RID: 23054
		[Description("graphicsheight")]
		GFX_HEIGHT,
		// Token: 0x04005A0F RID: 23055
		[Description("graphicsfullscreen")]
		GFX_FULLSCREEN,
		// Token: 0x04005A10 RID: 23056
		[Description("hasseennewcinematic")]
		HAS_SEEN_NEW_CINEMATIC,
		// Token: 0x04005A11 RID: 23057
		[Description("graphicsquality")]
		GFX_QUALITY,
		// Token: 0x04005A12 RID: 23058
		[Description("fakepackopening")]
		FAKE_PACK_OPENING,
		// Token: 0x04005A13 RID: 23059
		[Description("fakepackcount")]
		FAKE_PACK_COUNT,
		// Token: 0x04005A14 RID: 23060
		[Description("healthygamingdebug")]
		HEALTHY_GAMING_DEBUG,
		// Token: 0x04005A15 RID: 23061
		[Description("laststate")]
		LAST_SCENE_MODE,
		// Token: 0x04005A16 RID: 23062
		[Description("locale")]
		LOCALE,
		// Token: 0x04005A17 RID: 23063
		[Description("idlekicker")]
		IDLE_KICKER,
		// Token: 0x04005A18 RID: 23064
		[Description("idlekicktime")]
		IDLE_KICK_TIME,
		// Token: 0x04005A19 RID: 23065
		[Description("backgroundsound")]
		BACKGROUND_SOUND,
		// Token: 0x04005A1A RID: 23066
		[Description("preferredregion")]
		PREFERRED_REGION,
		// Token: 0x04005A1B RID: 23067
		[Description("forceShowIks")]
		FORCE_SHOW_IKS,
		// Token: 0x04005A1C RID: 23068
		[Description("peguidebug")]
		PEGUI_DEBUG,
		// Token: 0x04005A1D RID: 23069
		[Description("nearbyplayers2")]
		NEARBY_PLAYERS,
		// Token: 0x04005A1E RID: 23070
		[Description("wincameraclear")]
		GFX_WIN_CAMERA_CLEAR,
		// Token: 0x04005A1F RID: 23071
		[Description("msaa")]
		GFX_MSAA,
		// Token: 0x04005A20 RID: 23072
		[Description("fxaa")]
		GFX_FXAA,
		// Token: 0x04005A21 RID: 23073
		[Description("targetframerate")]
		GFX_TARGET_FRAME_RATE,
		// Token: 0x04005A22 RID: 23074
		[Description("vsync")]
		GFX_VSYNC,
		// Token: 0x04005A23 RID: 23075
		[Description("cardback")]
		CARD_BACK,
		// Token: 0x04005A24 RID: 23076
		[Description("cardback2")]
		CARD_BACK2,
		// Token: 0x04005A25 RID: 23077
		[Description("localtutorialprogress")]
		LOCAL_TUTORIAL_PROGRESS,
		// Token: 0x04005A26 RID: 23078
		[Description("connecttobnet")]
		CONNECT_TO_AURORA,
		// Token: 0x04005A27 RID: 23079
		[Description("reconnect")]
		RECONNECT,
		// Token: 0x04005A28 RID: 23080
		[Description("reconnectTimeout")]
		RECONNECT_TIMEOUT,
		// Token: 0x04005A29 RID: 23081
		[Description("reconnectRetryTime")]
		RECONNECT_RETRY_TIME,
		// Token: 0x04005A2A RID: 23082
		[Description("changedcardsdata")]
		CHANGED_CARDS_DATA,
		// Token: 0x04005A2B RID: 23083
		[Description("kelthuzadtaunts")]
		KELTHUZADTAUNTS,
		// Token: 0x04005A2C RID: 23084
		[Description("winposx")]
		GFX_WIN_POSX,
		// Token: 0x04005A2D RID: 23085
		[Description("winposy")]
		GFX_WIN_POSY,
		// Token: 0x04005A2E RID: 23086
		[Description("preferredcdnindex")]
		PREFERRED_CDN_INDEX,
		// Token: 0x04005A2F RID: 23087
		[Description("lastfaileddopversion")]
		LAST_FAILED_DOP_VERSION,
		// Token: 0x04005A30 RID: 23088
		[Description("touchmode")]
		TOUCH_MODE,
		// Token: 0x04005A31 RID: 23089
		[Description("gfxdevicewarning")]
		SHOWN_GFX_DEVICE_WARNING,
		// Token: 0x04005A32 RID: 23090
		[Description("intro")]
		INTRO,
		// Token: 0x04005A33 RID: 23091
		[Description("tutoriallostprogress")]
		TUTORIAL_LOST_PROGRESS,
		// Token: 0x04005A34 RID: 23092
		[Description("errorScreen")]
		ERROR_SCREEN,
		// Token: 0x04005A35 RID: 23093
		[Description("innkeepersSpecialViews")]
		WELCOME_QUEST_VIEWS,
		// Token: 0x04005A36 RID: 23094
		[Description("innkeepersSpecialLastDownloadTime")]
		IKS_LAST_DOWNLOAD_TIME,
		// Token: 0x04005A37 RID: 23095
		[Description("innkeepersSpecialLastResponse")]
		IKS_LAST_DOWNLOAD_RESPONSE,
		// Token: 0x04005A38 RID: 23096
		[Description("innkeepersSpecialCacheAge")]
		IKS_CACHE_AGE,
		// Token: 0x04005A39 RID: 23097
		[Description("innkeepersSpecialLastStoredResponse")]
		IKS_LAST_STORED_RESPONSE,
		// Token: 0x04005A3A RID: 23098
		[Description("cheatHistory")]
		CHEAT_HISTORY,
		// Token: 0x04005A3B RID: 23099
		[Description("preloadCardAssets")]
		PRELOAD_CARD_ASSETS,
		// Token: 0x04005A3C RID: 23100
		[Description("collectionPremiumType")]
		COLLECTION_PREMIUM_TYPE,
		// Token: 0x04005A3D RID: 23101
		[Description("devTimescale")]
		DEV_TIMESCALE,
		// Token: 0x04005A3E RID: 23102
		[Description("innkeepersSpecialLastShownAd")]
		IKS_LAST_SHOWN_AD,
		// Token: 0x04005A3F RID: 23103
		[Description("seenPackProductList")]
		SEEN_PACK_PRODUCT_LIST,
		// Token: 0x04005A40 RID: 23104
		[Description("showStandardOnly")]
		SHOW_STANDARD_ONLY,
		// Token: 0x04005A41 RID: 23105
		[Description("showSetRotationIntroVisuals")]
		SHOW_SET_ROTATION_INTRO_VISUALS,
		// Token: 0x04005A42 RID: 23106
		[Description("skipallmulligans")]
		SKIP_ALL_MULLIGANS,
		// Token: 0x04005A43 RID: 23107
		[Description("isTemporaryAccountCheat")]
		IS_TEMPORARY_ACCOUNT_CHEAT,
		// Token: 0x04005A44 RID: 23108
		[Description("temporaryAccountData")]
		TEMPORARY_ACCOUNT_DATA,
		// Token: 0x04005A45 RID: 23109
		[Description("disallowedCloudStorage")]
		DISALLOWED_CLOUD_STORAGE,
		// Token: 0x04005A46 RID: 23110
		[Description("createdAccount")]
		CREATED_ACCOUNT,
		// Token: 0x04005A47 RID: 23111
		[Description("lastEventHealUpDate")]
		LAST_HEAL_UP_EVENT_DATE,
		// Token: 0x04005A48 RID: 23112
		[Description("pushNotificationStatus")]
		PUSH_NOTIFICATION_STATUS,
		// Token: 0x04005A49 RID: 23113
		[Description("dbfXmlLoading")]
		DBF_XML_LOADING,
		// Token: 0x04005A4A RID: 23114
		[Description("hasShownDevicePerformanceWarning")]
		HAS_SHOWN_DEVICE_PERFORMANCE_WARNING,
		// Token: 0x04005A4B RID: 23115
		[Description("screenshotDirectory")]
		SCREENSHOT_DIRECTORY,
		// Token: 0x04005A4C RID: 23116
		[Description("simulatingCellular")]
		SIMULATE_CELLULAR,
		// Token: 0x04005A4D RID: 23117
		[Description("assetDownloadEnabled")]
		ASSET_DOWNLOAD_ENABLED,
		// Token: 0x04005A4E RID: 23118
		[Description("updateState")]
		UPDATE_STATE,
		// Token: 0x04005A4F RID: 23119
		[Description("nativeUpdateState")]
		NATIVE_UPDATE_STATE,
		// Token: 0x04005A50 RID: 23120
		[Description("AskUnknownApps")]
		ASK_UNKNOWN_APPS,
		// Token: 0x04005A51 RID: 23121
		[Description("launchCount")]
		LAUNCH_COUNT,
		// Token: 0x04005A52 RID: 23122
		[Description("isInstallReported")]
		IS_INSTALL_REPORTED,
		// Token: 0x04005A53 RID: 23123
		[Description("firstInstallTime")]
		FIRST_INSTALL_TIME,
		// Token: 0x04005A54 RID: 23124
		[Description("updatedClientVersion")]
		UPDATED_CLIENT_VERSION,
		// Token: 0x04005A55 RID: 23125
		[Description("simulateNoInternet")]
		SIMULATE_NO_INTERNET,
		// Token: 0x04005A56 RID: 23126
		[Description("updateStopLevel")]
		UPDATE_STOP_LEVEL,
		// Token: 0x04005A57 RID: 23127
		[Description("maxDownloadSpeed")]
		MAX_DOWNLOAD_SPEED,
		// Token: 0x04005A58 RID: 23128
		[Description("streamingSpeedInGame")]
		STREAMING_SPEED_IN_GAME,
		// Token: 0x04005A59 RID: 23129
		[Description("autoConvertVirtualCurrency")]
		AUTOCONVERT_VIRTUAL_CURRENCY,
		// Token: 0x04005A5A RID: 23130
		[Description("streamerMode")]
		STREAMER_MODE,
		// Token: 0x04005A5B RID: 23131
		[Description("latestSeenShopProductList")]
		LATEST_SEEN_SHOP_PRODUCT_LIST,
		// Token: 0x04005A5C RID: 23132
		[Description("latestDisplayedShopProductList")]
		LATEST_DISPLAYED_SHOP_PRODUCT_LIST,
		// Token: 0x04005A5D RID: 23133
		[Description("rankDebug")]
		RANK_DEBUG,
		// Token: 0x04005A5E RID: 23134
		[Description("debugCursor")]
		DEBUG_CURSOR,
		// Token: 0x04005A5F RID: 23135
		[Description("crashCount")]
		CRASH_COUNT,
		// Token: 0x04005A60 RID: 23136
		[Description("exceptionCount")]
		EXCEPTION_COUNT,
		// Token: 0x04005A61 RID: 23137
		[Description("lowMemoryCount")]
		LOW_MEMORY_COUNT,
		// Token: 0x04005A62 RID: 23138
		[Description("closedWithoutCrash")]
		CLOSED_WITHOUT_CRASH,
		// Token: 0x04005A63 RID: 23139
		[Description("ExceptionHash")]
		EXCEPTION_HASH,
		// Token: 0x04005A64 RID: 23140
		[Description("LastExceptionHash")]
		LAST_EXCEPTION_HASH,
		// Token: 0x04005A65 RID: 23141
		[Description("CrashInARowCount")]
		CRASH_IN_A_ROW_COUNT,
		// Token: 0x04005A66 RID: 23142
		[Description("SameExceptionCount")]
		SAME_EXCEPTION_COUNT,
		// Token: 0x04005A67 RID: 23143
		[Description("CellPromptThreshold")]
		CELL_PROMPT_THRESHOLD,
		// Token: 0x04005A68 RID: 23144
		[Description("DownloadAllFinished")]
		DOWNLOAD_ALL_FINISHED,
		// Token: 0x04005A69 RID: 23145
		[Description("DelayedReporterStop")]
		DELAYED_REPORTER_STOP,
		// Token: 0x04005A6A RID: 23146
		[Description("ScreenshakeEnabled")]
		SCREEN_SHAKE_ENABLED,
		// Token: 0x04005A6B RID: 23147
		[Description("hudconfig")]
		HUD_CONFIG,
		// Token: 0x04005A6C RID: 23148
		[Description("hudScale")]
		HUD_SCALE,
		// Token: 0x04005A6D RID: 23149
		[Description("EnabledLogList")]
		ENABLED_LOG_LIST,
		// Token: 0x04005A6E RID: 23150
		[Description("hasSeenClipboardNotification")]
		HAS_SEEN_CLIPBOARD_NOTIFICATION,
		// Token: 0x04005A6F RID: 23151
		[Description("serverOptionsVersion")]
		SERVER_OPTIONS_VERSION,
		// Token: 0x04005A70 RID: 23152
		[Description("pagemouseovers")]
		PAGE_MOUSE_OVERS,
		// Token: 0x04005A71 RID: 23153
		[Description("covermouseovers")]
		COVER_MOUSE_OVERS,
		// Token: 0x04005A72 RID: 23154
		[Description("aimode")]
		AI_MODE,
		// Token: 0x04005A73 RID: 23155
		[Description("practicetipporgress")]
		TIP_PRACTICE_PROGRESS,
		// Token: 0x04005A74 RID: 23156
		[Description("playtipprogress")]
		TIP_PLAY_PROGRESS,
		// Token: 0x04005A75 RID: 23157
		[Description("forgetipprogress")]
		TIP_FORGE_PROGRESS,
		// Token: 0x04005A76 RID: 23158
		[Description("lastChosenPreconHero")]
		LAST_PRECON_HERO_CHOSEN,
		// Token: 0x04005A77 RID: 23159
		[Description("lastChosenCustomDeck")]
		LAST_CUSTOM_DECK_CHOSEN,
		// Token: 0x04005A78 RID: 23160
		[Description("selectedAdventure")]
		SELECTED_ADVENTURE,
		// Token: 0x04005A79 RID: 23161
		[Description("selectedAdventureMode")]
		SELECTED_ADVENTURE_MODE,
		// Token: 0x04005A7A RID: 23162
		[Description("lastselectedbooster")]
		LAST_SELECTED_STORE_BOOSTER_ID,
		// Token: 0x04005A7B RID: 23163
		[Description("lastselectedadventure")]
		LAST_SELECTED_STORE_ADVENTURE_ID,
		// Token: 0x04005A7C RID: 23164
		[Description("lastselectedhero")]
		LAST_SELECTED_STORE_HERO_ID,
		// Token: 0x04005A7D RID: 23165
		[Description("seenTB")]
		LATEST_SEEN_TAVERNBRAWL_SEASON,
		// Token: 0x04005A7E RID: 23166
		[Description("seenTBScreen")]
		LATEST_SEEN_TAVERNBRAWL_SEASON_CHALKBOARD,
		// Token: 0x04005A7F RID: 23167
		[Description("seenCrazyRulesQuote")]
		TIMES_SEEN_TAVERNBRAWL_CRAZY_RULES_QUOTE,
		// Token: 0x04005A80 RID: 23168
		[Description("setRotationIntroProgress")]
		SET_ROTATION_INTRO_PROGRESS,
		// Token: 0x04005A81 RID: 23169
		[Description("timesMousedOverSwitchFormatButton")]
		TIMES_MOUSED_OVER_SWITCH_FORMAT_BUTTON,
		// Token: 0x04005A82 RID: 23170
		[Description("returningPlayerBannerSeen")]
		RETURNING_PLAYER_BANNER_SEEN,
		// Token: 0x04005A83 RID: 23171
		[Description("seenTBSessionLimit")]
		LATEST_SEEN_TAVERNBRAWL_SESSION_LIMIT,
		// Token: 0x04005A84 RID: 23172
		[Description("lastTavernJoined")]
		LAST_TAVERN_JOINED,
		// Token: 0x04005A85 RID: 23173
		[Description("seenFSGB")]
		LATEST_SEEN_FIRESIDEBRAWL_SEASON,
		// Token: 0x04005A86 RID: 23174
		[Description("seenFSGBScreen")]
		LATEST_SEEN_FIRESIDEBRAWL_SEASON_CHALKBOARD,
		// Token: 0x04005A87 RID: 23175
		[Description("seenScheduledDoubleGoldVO")]
		LATEST_SEEN_SCHEDULED_DOUBLE_GOLD_VO,
		// Token: 0x04005A88 RID: 23176
		[Description("seenScheduledAllPopupsShownVO")]
		LATEST_SEEN_SCHEDULED_ALL_POPUPS_SHOWN_VO,
		// Token: 0x04005A89 RID: 23177
		[Description("seenScheduledEnteredArenaDraftVO")]
		LATEST_SEEN_SCHEDULED_ENTERED_ARENA_DRAFT,
		// Token: 0x04005A8A RID: 23178
		[Description("seenScheduledLoginFlowComplete")]
		LATEST_SEEN_SCHEDULED_LOGIN_FLOW_COMPLETE,
		// Token: 0x04005A8B RID: 23179
		[Description("seenWelcomeQuestDialog")]
		LATEST_SEEN_WELCOME_QUEST_DIALOG,
		// Token: 0x04005A8C RID: 23180
		[Description("seenCurrencyChangeMessageForVersion")]
		LATEST_SEEN_CURRENCY_CHANGED_VERSION,
		// Token: 0x04005A8D RID: 23181
		[Description("latestSeenAdventure")]
		LATEST_SEEN_ADVENTURE,
		// Token: 0x04005A8E RID: 23182
		[Description("seenScheduledWelcomeQuestVO")]
		LATEST_SEEN_SCHEDULED_WELCOME_QUEST_SHOWN_VO,
		// Token: 0x04005A8F RID: 23183
		[Description("seenScheduledGenericRewardShownVO")]
		LATEST_SEEN_SCHEDULED_GENERIC_REWARD_SHOWN_VO,
		// Token: 0x04005A90 RID: 23184
		[Description("seenScheduledArenaRewardShownVO")]
		LATEST_SEEN_SCHEDULED_ARENA_REWARD_SHOWN_VO,
		// Token: 0x04005A91 RID: 23185
		[Description("lastSelectedStorePackType")]
		LAST_SELECTED_STORE_PACK_TYPE,
		// Token: 0x04005A92 RID: 23186
		[Description("whizbangPopupCounter")]
		WHIZBANG_POPUP_COUNTER,
		// Token: 0x04005A93 RID: 23187
		[Description("setRotationIntroProgressNewPlayer")]
		SET_ROTATION_INTRO_PROGRESS_NEW_PLAYER,
		// Token: 0x04005A94 RID: 23188
		[Description("hasclickedtournament")]
		HAS_CLICKED_TOURNAMENT,
		// Token: 0x04005A95 RID: 23189
		[Description("hasopenedbooster")]
		HAS_OPENED_BOOSTER,
		// Token: 0x04005A96 RID: 23190
		[Description("hasseentournament")]
		HAS_SEEN_TOURNAMENT,
		// Token: 0x04005A97 RID: 23191
		[Description("hasseencollectionmanager")]
		HAS_SEEN_COLLECTIONMANAGER,
		// Token: 0x04005A98 RID: 23192
		[Description("justfinishedtutorial")]
		JUST_FINISHED_TUTORIAL,
		// Token: 0x04005A99 RID: 23193
		[Description("showadvancedcollectionmanager")]
		SHOW_ADVANCED_COLLECTIONMANAGER,
		// Token: 0x04005A9A RID: 23194
		[Description("hasseenpracticetray")]
		HAS_SEEN_PRACTICE_TRAY,
		// Token: 0x04005A9B RID: 23195
		[Description("firstHubVisitPastTutorial")]
		HAS_SEEN_HUB,
		// Token: 0x04005A9C RID: 23196
		[Description("firstdeckcomplete")]
		HAS_FINISHED_A_DECK,
		// Token: 0x04005A9D RID: 23197
		[Description("hasseenforge")]
		HAS_SEEN_FORGE,
		// Token: 0x04005A9E RID: 23198
		[Description("hasseenforgeherochoice")]
		HAS_SEEN_FORGE_HERO_CHOICE,
		// Token: 0x04005A9F RID: 23199
		[Description("hasseenforgecardchoice")]
		HAS_SEEN_FORGE_CARD_CHOICE,
		// Token: 0x04005AA0 RID: 23200
		[Description("hasseenforgecardchoice2")]
		HAS_SEEN_FORGE_CARD_CHOICE2,
		// Token: 0x04005AA1 RID: 23201
		[Description("hasseenforgeplaymode")]
		HAS_SEEN_FORGE_PLAY_MODE,
		// Token: 0x04005AA2 RID: 23202
		[Description("hasseenforge1win")]
		HAS_SEEN_FORGE_1WIN,
		// Token: 0x04005AA3 RID: 23203
		[Description("hasseenforge2loss")]
		HAS_SEEN_FORGE_2LOSS,
		// Token: 0x04005AA4 RID: 23204
		[Description("hasseenforgeretire")]
		HAS_SEEN_FORGE_RETIRE,
		// Token: 0x04005AA5 RID: 23205
		[Description("hasseenmulligan")]
		HAS_SEEN_MULLIGAN,
		// Token: 0x04005AA6 RID: 23206
		[Description("hasSeenExpertAI")]
		HAS_SEEN_EXPERT_AI,
		// Token: 0x04005AA7 RID: 23207
		[Description("hasSeenExpertAIUnlock")]
		HAS_SEEN_EXPERT_AI_UNLOCK,
		// Token: 0x04005AA8 RID: 23208
		[Description("hasseendeckhelper")]
		HAS_SEEN_DECK_HELPER,
		// Token: 0x04005AA9 RID: 23209
		[Description("hasSeenPackOpening")]
		HAS_SEEN_PACK_OPENING,
		// Token: 0x04005AAA RID: 23210
		[Description("hasSeenPracticeMode")]
		HAS_SEEN_PRACTICE_MODE,
		// Token: 0x04005AAB RID: 23211
		[Description("hasSeenCustomDeckPicker")]
		HAS_SEEN_CUSTOM_DECK_PICKER,
		// Token: 0x04005AAC RID: 23212
		[Description("hasSeenAllBasicClassCardsComplete")]
		HAS_SEEN_ALL_BASIC_CLASS_CARDS_COMPLETE,
		// Token: 0x04005AAD RID: 23213
		[Description("hasBeenNudgedToCM")]
		HAS_BEEN_NUDGED_TO_CM,
		// Token: 0x04005AAE RID: 23214
		[Description("hasAddedCardsToDeck")]
		HAS_ADDED_CARDS_TO_DECK,
		// Token: 0x04005AAF RID: 23215
		[Description("tipCraftingUnlocked")]
		TIP_CRAFTING_UNLOCKED,
		// Token: 0x04005AB0 RID: 23216
		[Description("hasPlayedExpertAI")]
		HAS_PLAYED_EXPERT_AI,
		// Token: 0x04005AB1 RID: 23217
		[Description("hasDisenchanted")]
		HAS_DISENCHANTED,
		// Token: 0x04005AB2 RID: 23218
		[Description("hasSeenShowAllCardsReminder")]
		HAS_SEEN_SHOW_ALL_CARDS_REMINDER,
		// Token: 0x04005AB3 RID: 23219
		[Description("hasSeenCraftingInstruction")]
		HAS_SEEN_CRAFTING_INSTRUCTION,
		// Token: 0x04005AB4 RID: 23220
		[Description("hasCrafted")]
		HAS_CRAFTED,
		// Token: 0x04005AB5 RID: 23221
		[Description("inRankedPlayMode")]
		IN_RANKED_PLAY_MODE,
		// Token: 0x04005AB6 RID: 23222
		[Description("hasSeenTheCoin")]
		HAS_SEEN_THE_COIN,
		// Token: 0x04005AB7 RID: 23223
		[Description("hasseen100goldReminder")]
		HAS_SEEN_100g_REMINDER,
		// Token: 0x04005AB8 RID: 23224
		[Description("hasSeenGoldQtyInstruction")]
		HAS_SEEN_GOLD_QTY_INSTRUCTION,
		// Token: 0x04005AB9 RID: 23225
		[Description("hasSeenLevel3")]
		HAS_SEEN_LEVEL_3,
		// Token: 0x04005ABA RID: 23226
		[Description("hasLostInArena")]
		HAS_LOST_IN_ARENA,
		// Token: 0x04005ABB RID: 23227
		[Description("hasRunOutOfQuests")]
		HAS_RUN_OUT_OF_QUESTS,
		// Token: 0x04005ABC RID: 23228
		[Description("hasAckedArenaRewards")]
		HAS_ACKED_ARENA_REWARDS,
		// Token: 0x04005ABD RID: 23229
		[Description("hasSeenStealthTaunter")]
		HAS_SEEN_STEALTH_TAUNTER,
		// Token: 0x04005ABE RID: 23230
		[Description("friendslistrequestsectionhide")]
		FRIENDS_LIST_REQUEST_SECTION_HIDE,
		// Token: 0x04005ABF RID: 23231
		[Description("friendslistcurrentgamesectionhide")]
		FRIENDS_LIST_CURRENTGAME_SECTION_HIDE,
		// Token: 0x04005AC0 RID: 23232
		[Description("friendslistfriendsectionhide")]
		FRIENDS_LIST_FRIEND_SECTION_HIDE,
		// Token: 0x04005AC1 RID: 23233
		[Description("friendslistnearbysectionhide")]
		FRIENDS_LIST_NEARBYPLAYER_SECTION_HIDE,
		// Token: 0x04005AC2 RID: 23234
		[Description("friendslistrecruitsectionhide")]
		FRIENDS_LIST_RECRUIT_SECTION_HIDE,
		// Token: 0x04005AC3 RID: 23235
		[Description("hasSeenHeroicWarning")]
		HAS_SEEN_HEROIC_WARNING,
		// Token: 0x04005AC4 RID: 23236
		[Description("hasSeenNaxx")]
		HAS_SEEN_NAXX,
		// Token: 0x04005AC5 RID: 23237
		[Description("hasEnteredNaxx")]
		HAS_ENTERED_NAXX,
		// Token: 0x04005AC6 RID: 23238
		[Description("hasSeenNaxxClassChallenge")]
		HAS_SEEN_NAXX_CLASS_CHALLENGE,
		// Token: 0x04005AC7 RID: 23239
		[Description("bundleJustPurchaseInHub")]
		BUNDLE_JUST_PURCHASE_IN_HUB,
		// Token: 0x04005AC8 RID: 23240
		[Description("hasPlayedNaxx")]
		HAS_PLAYED_NAXX,
		// Token: 0x04005AC9 RID: 23241
		[Description("spectatoropenjoin")]
		SPECTATOR_OPEN_JOIN,
		// Token: 0x04005ACA RID: 23242
		[Description("hasstartedadeck")]
		HAS_STARTED_A_DECK,
		// Token: 0x04005ACB RID: 23243
		[Description("hasseencollectionmanagerafterpractice")]
		HAS_SEEN_COLLECTIONMANAGER_AFTER_PRACTICE,
		// Token: 0x04005ACC RID: 23244
		[Description("hasSeenBRM")]
		HAS_SEEN_BRM,
		// Token: 0x04005ACD RID: 23245
		[Description("hasSeenLOE")]
		HAS_SEEN_LOE,
		// Token: 0x04005ACE RID: 23246
		[Description("hasClickedManaTab")]
		HAS_CLICKED_MANA_TAB,
		// Token: 0x04005ACF RID: 23247
		[Description("hasseenforgemaxwin")]
		HAS_SEEN_FORGE_MAX_WIN,
		// Token: 0x04005AD0 RID: 23248
		[Description("hasheardtgtpackvo")]
		DEPRECATED_HAS_HEARD_TGT_PACK_VO,
		// Token: 0x04005AD1 RID: 23249
		[Description("hasseenloestaffdisappear")]
		HAS_SEEN_LOE_STAFF_DISAPPEAR,
		// Token: 0x04005AD2 RID: 23250
		[Description("hasseenloestaffreappear")]
		HAS_SEEN_LOE_STAFF_REAPPEAR,
		// Token: 0x04005AD3 RID: 23251
		[Description("hasSeenUnlockAllHeroesTransition")]
		HAS_SEEN_UNLOCK_ALL_HEROES_TRANSITION,
		// Token: 0x04005AD4 RID: 23252
		[Description("createdFirstDeckForClass")]
		SKIP_DECK_TEMPLATE_PAGE_FOR_CLASS_FLAGS,
		// Token: 0x04005AD5 RID: 23253
		[Description("hasSeenDeckTemplateScreen")]
		HAS_SEEN_DECK_TEMPLATE_SCREEN,
		// Token: 0x04005AD6 RID: 23254
		[Description("hasClickedDeckTemplateReplace")]
		HAS_CLICKED_DECK_TEMPLATE_REPLACE,
		// Token: 0x04005AD7 RID: 23255
		[Description("hasSeenDeckTemplateGhostCard")]
		HAS_SEEN_DECK_TEMPLATE_GHOST_CARD,
		// Token: 0x04005AD8 RID: 23256
		[Description("hasRemovedCardFromDeck")]
		HAS_REMOVED_CARD_FROM_DECK,
		// Token: 0x04005AD9 RID: 23257
		[Description("hasSeenDeleteDeckReminder")]
		HAS_SEEN_DELETE_DECK_REMINDER,
		// Token: 0x04005ADA RID: 23258
		[Description("hasClickedCollectionButtonForNewCard")]
		HAS_CLICKED_COLLECTION_BUTTON_FOR_NEW_CARD,
		// Token: 0x04005ADB RID: 23259
		[Description("hasClickedCollectionButtonForNewDeck")]
		HAS_CLICKED_COLLECTION_BUTTON_FOR_NEW_DECK,
		// Token: 0x04005ADC RID: 23260
		[Description("inWildMode")]
		IN_WILD_MODE,
		// Token: 0x04005ADD RID: 23261
		[Description("hasSeenWildModeVO")]
		HAS_SEEN_WILD_MODE_VO,
		// Token: 0x04005ADE RID: 23262
		[Description("hasSeenStandardModeTutorial")]
		HAS_SEEN_STANDARD_MODE_TUTORIAL,
		// Token: 0x04005ADF RID: 23263
		[Description("needsToMakeStandardDeck")]
		NEEDS_TO_MAKE_STANDARD_DECK,
		// Token: 0x04005AE0 RID: 23264
		[Description("hasSeenInvalidRotatedCard")]
		HAS_SEEN_INVALID_ROTATED_CARD,
		// Token: 0x04005AE1 RID: 23265
		[Description("showSwitchToWildOnPlayScreen")]
		SHOW_SWITCH_TO_WILD_ON_PLAY_SCREEN,
		// Token: 0x04005AE2 RID: 23266
		[Description("showSwitchToWildOnCreateDeck")]
		SHOW_SWITCH_TO_WILD_ON_CREATE_DECK,
		// Token: 0x04005AE3 RID: 23267
		[Description("showWildDisclaimerPopupOnCreateDeck")]
		SHOW_WILD_DISCLAIMER_POPUP_ON_CREATE_DECK,
		// Token: 0x04005AE4 RID: 23268
		[Description("hasSeenBasicDeckWarning")]
		HAS_SEEN_BASIC_DECK_WARNING,
		// Token: 0x04005AE5 RID: 23269
		[Description("glowCollectionButtonAfterSetRotation")]
		GLOW_COLLECTION_BUTTON_AFTER_SET_ROTATION,
		// Token: 0x04005AE6 RID: 23270
		[Description("hasSeenSetFilterTutorial")]
		HAS_SEEN_SET_FILTER_TUTORIAL,
		// Token: 0x04005AE7 RID: 23271
		[Description("hasSeenRAF")]
		HAS_SEEN_RAF,
		// Token: 0x04005AE8 RID: 23272
		[Description("hasSeenRAFRecruitURL")]
		HAS_SEEN_RAF_RECRUIT_URL,
		// Token: 0x04005AE9 RID: 23273
		[Description("hasSeenKara")]
		HAS_SEEN_KARA,
		// Token: 0x04005AEA RID: 23274
		[Description("hasseenheroicbrawl")]
		HAS_SEEN_HEROIC_BRAWL,
		// Token: 0x04005AEB RID: 23275
		[Description("showInnkeeperDeckDialogue")]
		SHOW_INNKEEPER_DECK_DIALOGUE,
		// Token: 0x04005AEC RID: 23276
		[Description("hasHeardReturningPlayerWelcomeBackVO")]
		HAS_HEARD_RETURNING_PLAYER_WELCOME_BACK_VO,
		// Token: 0x04005AED RID: 23277
		[Description("hasSeenReturningPlayerInnkeeperChallengeIntro")]
		HAS_SEEN_RETURNING_PLAYER_INNKEEPER_CHALLENGE_INTRO,
		// Token: 0x04005AEE RID: 23278
		[Description("hadItemThatWillBeRotatedInUpcomingEvent")]
		DEPRECATED_HAD_ITEM_THAT_WILL_BE_ROTATED_IN_UPCOMING_EVENT,
		// Token: 0x04005AEF RID: 23279
		[Description("shouldAutoCheckInToFiresideGatherings")]
		SHOULD_AUTO_CHECK_IN_TO_FIRESIDE_GATHERINGS,
		// Token: 0x04005AF0 RID: 23280
		[Description("hasClickedFiresideBrawlButton")]
		HAS_CLICKED_FIRESIDE_BRAWL_BUTTON,
		// Token: 0x04005AF1 RID: 23281
		[Description("hasClickedFiresideGatheringsButton")]
		HAS_CLICKED_FIRESIDE_GATHERINGS_BUTTON,
		// Token: 0x04005AF2 RID: 23282
		[Description("hasInitiatedFSGScan")]
		HAS_INITIATED_FIRESIDE_GATHERING_SCAN,
		// Token: 0x04005AF3 RID: 23283
		[Description("hasDisabledGoldensThisDraft")]
		HAS_DISABLED_GOLDENS_THIS_DRAFT,
		// Token: 0x04005AF4 RID: 23284
		[Description("hasSeenFreeArenaWinDialogThisDraft")]
		HAS_SEEN_FREE_ARENA_WIN_DIALOG_THIS_DRAFT,
		// Token: 0x04005AF5 RID: 23285
		[Description("hasSeenICC")]
		HAS_SEEN_ICC,
		// Token: 0x04005AF6 RID: 23286
		[Description("seenArenaSeasonStarting")]
		LATEST_SEEN_ARENA_SEASON_STARTING,
		// Token: 0x04005AF7 RID: 23287
		[Description("seenArenaSeasonEnding")]
		LATEST_SEEN_ARENA_SEASON_ENDING,
		// Token: 0x04005AF8 RID: 23288
		[Description("hasSeenLOOT")]
		HAS_SEEN_LOOT,
		// Token: 0x04005AF9 RID: 23289
		[Description("hasSeenLatestDungeonRunComplete")]
		HAS_SEEN_LATEST_DUNGEON_RUN_COMPLETE,
		// Token: 0x04005AFA RID: 23290
		[Description("hasSeenLOOTCharacterSelectVO")]
		HAS_SEEN_LOOT_CHARACTER_SELECT_VO,
		// Token: 0x04005AFB RID: 23291
		[Description("hasSeenLOOTWelcomeBannerVO")]
		HAS_SEEN_LOOT_WELCOME_BANNER_VO,
		// Token: 0x04005AFC RID: 23292
		[Description("hasSeenLOOTBossFlip1VO")]
		HAS_SEEN_LOOT_BOSS_FLIP_1_VO,
		// Token: 0x04005AFD RID: 23293
		[Description("hasSeenLOOTBossFlip2VO")]
		HAS_SEEN_LOOT_BOSS_FLIP_2_VO,
		// Token: 0x04005AFE RID: 23294
		[Description("hasSeenLOOTBossFlip3VO")]
		HAS_SEEN_LOOT_BOSS_FLIP_3_VO,
		// Token: 0x04005AFF RID: 23295
		[Description("hasSeenLOOTOfferTreasure1VO")]
		HAS_SEEN_LOOT_OFFER_TREASURE_1_VO,
		// Token: 0x04005B00 RID: 23296
		[Description("hasSeenLOOTOfferLootPacks1VO")]
		HAS_SEEN_LOOT_OFFER_LOOT_PACKS_1_VO,
		// Token: 0x04005B01 RID: 23297
		[Description("hasSeenLOOTOfferLootPacks2VO")]
		HAS_SEEN_LOOT_OFFER_LOOT_PACKS_2_VO,
		// Token: 0x04005B02 RID: 23298
		[Description("hasJustSeenLOOTNoTakeCandleVO")]
		HAS_JUST_SEEN_LOOT_NO_TAKE_CANDLE_VO,
		// Token: 0x04005B03 RID: 23299
		[Description("hasSeenLOOTInGameWinVO")]
		HAS_SEEN_LOOT_IN_GAME_WIN_VO,
		// Token: 0x04005B04 RID: 23300
		[Description("hasSeenLOOTInGameLoseVO")]
		HAS_SEEN_LOOT_IN_GAME_LOSE_VO,
		// Token: 0x04005B05 RID: 23301
		[Description("hasSeenLOOTInGameMulligan1VO")]
		HAS_SEEN_LOOT_IN_GAME_MULLIGAN_1_VO,
		// Token: 0x04005B06 RID: 23302
		[Description("hasSeenLOOTInGameMulligan2VO")]
		HAS_SEEN_LOOT_IN_GAME_MULLIGAN_2_VO,
		// Token: 0x04005B07 RID: 23303
		[Description("hasSeenLOOTCompleteAllClassesVO")]
		HAS_SEEN_LOOT_COMPLETE_ALL_CLASSES_VO,
		// Token: 0x04005B08 RID: 23304
		[Description("hasSeenLOOTBossHeroPower")]
		HAS_SEEN_LOOT_BOSS_HERO_POWER,
		// Token: 0x04005B09 RID: 23305
		[Description("hasSeenLOOTInGameLose2VO")]
		HAS_SEEN_LOOT_IN_GAME_LOSE_2_VO,
		// Token: 0x04005B0A RID: 23306
		[Description("hasSeenRankRevampEndOfGameWinsRequired")]
		HAS_SEEN_RANK_REVAMP_END_OF_GAME_WINS_REQUIRED,
		// Token: 0x04005B0B RID: 23307
		[Description("hasSeenGILBonusChallenge")]
		HAS_SEEN_GIL_BONUS_CHALLENGE,
		// Token: 0x04005B0C RID: 23308
		[Description("hasSeenPlayedTess")]
		HAS_SEEN_PLAYED_TESS,
		// Token: 0x04005B0D RID: 23309
		[Description("hasSeenPlayedDarius")]
		HAS_SEEN_PLAYED_DARIUS,
		// Token: 0x04005B0E RID: 23310
		[Description("hasSeenPlayedShaw")]
		HAS_SEEN_PLAYED_SHAW,
		// Token: 0x04005B0F RID: 23311
		[Description("hasSeenPlayedToki")]
		HAS_SEEN_PLAYED_TOKI,
		// Token: 0x04005B10 RID: 23312
		[Description("hasSeenBattlegroundsBoxButton")]
		HAS_SEEN_BATTLEGROUNDS_BOX_BUTTON
	}

}
