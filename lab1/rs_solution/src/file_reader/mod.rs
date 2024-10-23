use std::{ffi::OsStr, fs, path::PathBuf};

use text_data::TextData;

pub mod text_data;

pub struct FileReader {}

impl FileReader {
    pub fn read_txt_in_text_data(paths: &Vec<PathBuf>) -> Vec<TextData> {
        let mut text_data_list = Vec::new();
        for path in paths {
            match fs::read_to_string(path) {
                Ok(text) => {
                    let text_data = TextData::new(path.file_name().unwrap_or(OsStr::new("")), text);
                    text_data_list.push(text_data);
                }
                Err(e) => {
                    eprintln!("Error reading file {:?}: {}", path, e);
                }
            }
        }
        text_data_list
    }
}
