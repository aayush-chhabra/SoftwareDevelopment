define([
	"./likely_subtags",
	"./util/array/some"
], function( likelySubtags, arraySome ) {

	// Given a locale, remove any fields that Add Likely Subtags would add.
	// http://www.unicode.org/reports/tr35/#Likely_Subtags
	// 1. First get max = AddLikelySubtags(inputLocale). If an error is signaled, return it.
	// 2. Remove the variants from max.
	// 3. Then for trial in {language, language _ region, language _ script}. If AddLikelySubtags(trial) = max, then return trial + variants.
	// 4. If you do not get a match, return max + variants.
	// 
	// @maxLanguageId [Array] maxLanguageId tuple (see init.js).
	return function( Cldr, cldr, maxLanguageId ) {
		var match, matchFound,
			language = maxLanguageId[ 0 ],
			script = maxLanguageId[ 1 ],
			territory = maxLanguageId[ 2 ];

		// [3]
		matchFound = arraySome([
			[ [ language, "Zzzz", "ZZ" ], [ language ] ],
			[ [ language, "Zzzz", territory ], [ language, territory ] ],
			[ [ language, script, "ZZ" ], [ language, script ] ]
		], function( test ) {
			var result = likelySubtags( Cldr, cldr, test[ 0 ] );
			match = test[ 1 ];
			return result && result[ 0 ] === maxLanguageId[ 0 ] &&
				result[ 1 ] === maxLanguageId[ 1 ] &&
				result[ 2 ] === maxLanguageId[ 2 ];
		});

		// [4]
		return matchFound ?  match : maxLanguageId;
	};

});
