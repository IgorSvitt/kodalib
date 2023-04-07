<template>
  <div class="top-films">
    <div class="title-top-films">
      <span>Новые фильмы</span>
    </div>
    <div class="list-films" >
      <div>
        <carousel-film :films="information" :type="'f'"/>
      </div>
    </div>
  </div>
</template>

<script>
import {onMounted, ref} from "vue";
import CarouselFilm from "@/components/Pages/MainPage/ListFilm/CarouselFilms/CarouselFilm";
import axios from "axios";

export default {
  components: {CarouselFilm},
  setup() {
    const isLoading = ref(true);
    const information = ref(null)

    onMounted(async () => {
      isLoading.value = true
      await axios.get("http://5.44.46.158/api/films/last")
          .then(response => {
            information.value = response.data.data
            isLoading.value = false
          })
    })

    return {
      information,
      isLoading,
    }
  },
}
</script>

<style scoped>
.title-top-films {
  margin-top: 45px;
  color: #efefef;
  font-size: 32px;
  font-weight: 600;
}

.title-top-films {
  margin-bottom: 20px;
}

.list-films {
  margin-bottom: 20px;
  background-color: rgba(255, 255, 255, 0.1);
  padding: 20px 0;
  border-radius: 13px;
}


</style>