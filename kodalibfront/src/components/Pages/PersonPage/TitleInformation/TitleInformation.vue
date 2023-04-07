<template>
  <section class="title-information">
    <top-title :title="information" />
  </section>

</template>

<script>
import TopTitle from "@/components/Pages/PersonPage/TitleInformation/TopTitle/TopTitle";
export default {
  name: "title-information",
  components: {TopTitle},
  props: {
    information: {
      type: Object
    }
  },
  setup() {
  },
}
</script>

<style scoped>
.title-information {
  padding-top: 75px;
}



</style>