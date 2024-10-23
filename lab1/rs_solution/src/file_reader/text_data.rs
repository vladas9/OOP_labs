use std::{ffi::OsStr, fmt};

pub struct TextData<'a> {
    file_name: &'a OsStr,
    _text: String,
    number_of_vowels: i32,
    number_of_consonants: i32,
    number_of_letters: i32,
    number_of_sentences: i32,
    longest_word: String,
}

impl<'a> TextData<'a> {
    pub fn new(file_name: &'a OsStr, text: String) -> Self {
        let number_of_vowels = Self::count_vowels(&text);
        let number_of_consonants = Self::count_consonants(&text);
        let number_of_letters = number_of_vowels + number_of_consonants;
        let number_of_sentences = Self::count_sentences(&text);
        let longest_word = Self::find_longest_word(&text);

        TextData {
            file_name,
            _text: text,
            number_of_vowels,
            number_of_consonants,
            number_of_letters,
            number_of_sentences,
            longest_word: match longest_word {
                Some(word) => word,
                None => "".to_string(),
            },
        }
    }

    fn count_vowels(text: &String) -> i32 {
        text.chars().filter(|c| "aeiouAEIOU".contains(*c)).count() as i32
    }

    fn count_consonants(text: &String) -> i32 {
        text.chars()
            .filter(|c| c.is_alphabetic() && !"aeiouAEIOU".contains(*c))
            .count() as i32
    }

    fn count_sentences(text: &String) -> i32 {
        text.chars()
            .filter(|&c| c == '.' || c == '?' || c == '!')
            .count() as i32
    }

    fn find_longest_word(text: &String) -> Option<String> {
        let words = text
            .split(|c: char| !c.is_alphabetic())
            .filter(|w| !w.is_empty());

        words.max_by_key(|w| w.len()).map(|w| w.to_string())
    }
}

impl<'a> fmt::Display for TextData<'a> {
    fn fmt(&self, f: &mut fmt::Formatter) -> fmt::Result {
        write!(
            f,
            "File: {:?}\n\nLongest Word: {}\nVowels: {}\nConsonants: {}\nLetters: {}\nSentences: {}\n",
            self.file_name,
            self.longest_word,
            self.number_of_vowels,
            self.number_of_consonants,
            self.number_of_letters,
            self.number_of_sentences
        )
    }
}
