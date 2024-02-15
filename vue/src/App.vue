<template>
  <div>
    <TheHeader />
    <div class="main">
      <TheNavbar />
      <TheContent />
    </div>
  </div>
</template>

<script>
import TheHeader from './components/layout/TheHeader.vue';
import TheNavbar from './components/layout/TheNavbar.vue';
import TheContent from './components/layout/TheContent.vue';


export default {
  name: 'App',
  components: {
    TheHeader,
    TheNavbar,
    TheContent
  }
}
</script>

<style scoped>
@import url(style/main.css);
@import url(style/component/icon.css);
@import url(style/component/input.css);
@import url(style/component/button.css);
</style>
