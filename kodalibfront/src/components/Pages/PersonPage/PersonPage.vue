<template>
  <div class="person-page">
    <div class="container ">
      <div class="person-info">
        <title-information :information="information"/>
        <div class="main-information">
          <left-information :image="information.image" class="left-information"/>
          <center-information :information="information" class="center-information"/>
          <right-information :information="information.films" class="right-information"/>
        </div>

      </div>

    </div>
  </div>

</template>

<script>
import {useRoute} from "vue-router";
import {useStore} from "vuex";
import {computed, onMounted} from "vue";
import TitleInformation from "@/components/Pages/PersonPage/TitleInformation/TitleInformation";
import LeftInformation from "@/components/Pages/PersonPage/TitleInformation/LeftInformation/LeftInformation";
import RightInformation from "@/components/Pages/PersonPage/TitleInformation/RightInformation/RightInformation";
import CenterInformation from "@/components/Pages/PersonPage/TitleInformation/CenterIformation/CenterInformation";

export default {
  name: "PersonPage",
  components: {CenterInformation, RightInformation, LeftInformation, TitleInformation},


  setup() {
    const route = useRoute()
    const store = useStore()

    const getPerson = () => store.dispatch("people/getPersonApi", route.params.id)
    console.log(route.params.id)
    onMounted(getPerson)

    const information = computed(() => store.state.people.person)

    return {
      information
    }
  }
}
</script>

<style scoped>
.person-page {
  background-color: #efefef;
  height: 100vh;
}

.person-info {
  background-color: #ffffff;
  height: 100vh;
  padding-left: 20px;
}

.main-information{
  display: flex;
}

.left-information{
  width: 25%;
}

.center-information{
  width: 50%;
}

.right-information{
  width: 25%;
}
</style>