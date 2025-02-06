<template>
  <v-container>
    <v-row align="center">
      <v-col cols="8">
        <v-file-input
          id="fileInput"
          v-model="file"
          label="Upload File"
          accept=".txt,.csv"
        ></v-file-input>
      </v-col>
      <v-col cols="4">
        <v-btn :disabled="!file" color="teal" @click="parseInterview">
          Send
        </v-btn>
      </v-col>
    </v-row>
  </v-container>
  <v-container>
    <Text
      v-for='segment in segments'
      :text='segment.text'
      :theme='segment.theme'
      :aiThemes='segment.aiThemes'></Text>
  </v-container>
</template>

<script>
  import text from './Text.vue';
  import { InterviewOneResponse } from './SegmentData.js';
  export default {
    data() {
      return {
        file: null,
        interviewSegments: [],
        themeSegments: [],
        segments: [],
        themeIndexes: []
      };
    },
    methods: {
      async parseInterview() {
        if (!this.file) return;

        let fileContent = await this.readFile(this.file);
        this.segments = [];

        this.themeIndexes = InterviewOneResponse;

        this.themeIndexes.sort((a, b) => b.index - a.index);

        for (const themeIndex of this.themeIndexes) {
          const startIndex = themeIndex.index;
          const endIndex = startIndex + themeIndex.length;

          this.segments.unshift({ text: fileContent.slice(endIndex) });
          this.segments.unshift({
            text: fileContent.slice(startIndex, endIndex),
            theme: themeIndex.theme,
            aiThemes: themeIndex.aiThemes
          });

          fileContent = fileContent.slice(0, startIndex);
        }

        this.segments.unshift({ text: fileContent });
      },
      handleSend() {
        if (!this.file) return;

        const url = 'http://localhost:5087/interviews';
        const formData = new FormData();
        formData.append('interview', document.getElementById('fileInput').files[0]);

        fetch(url, {
          method: 'POST',
          body: formData
        })
          .then(response => response.json())
          .then(data => this.themeIndexes = data)
          .then(data => this.parseInterview())
          .catch(error => console.error(error));
      },
      readFile(file) {
        return new Promise((resolve, reject) => {
          const reader = new FileReader();
          reader.onload = (event) => resolve(event.target.result);
          reader.onerror = (error) => reject(error);
          reader.readAsText(file);
        });
      },
    },
  };
</script>
