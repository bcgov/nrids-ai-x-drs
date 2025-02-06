<template>
  <v-chip v-if="theme" class="ma-2" color="green">
    {{theme}}
  </v-chip>
  <v-chip v-for="aiTheme in aiThemes" class="ma-2" color="red">
    {{aiTheme}}
  </v-chip>
  <pre class="rounded pl-2" :class="{ 'bg-teal': theme || aiThemes }">{{text}}</pre>
</template>

<script setup>
  defineProps(['text', 'theme', 'aiThemes'])
</script>

<script>
  export default { };
</script>

<style>
pre {
  white-space: pre-wrap;
  font-family: monospace;
}
</style>
