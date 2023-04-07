import { createRouter, createWebHistory } from "vue-router";
import Main from "@/components/Pages/MainPage/Main";
import FilmPage from "@/components/Pages/FilmPage/FilmPage";
import AdminPanel from "@/components/Pages/AdminPanel/AdminPanel";
import PersonPage from "@/components/Pages/PersonPage/PersonPage";
import SeriesPage from "@/components/Pages/SeriesPage/SeriesPage";
import EpisodeVideoPlayer from "@/components/Pages/SeriesPage/EpisodeVideoPlayer/EpisodeVideoPlayer";
import FilmsPage from "@/components/Pages/FilmsPage/FilmsPage";
import AllSeriesPage from "@/components/Pages/AllSeriesPage/AllSeriesPage";
import NotFound from "@/components/Pages/ErorPages/NotFound";

const routes = [
    {
        path: "/",
        component: Main,
    },
    {
        path: "/film/:id",
        component: FilmPage,
    },
    {
        path: "/person/:id",
        component: PersonPage,
    },
    {
        path: "/adminpanel",
        component: AdminPanel,
    },
    {
        path: "/series/:id",
        component: SeriesPage,
    },
    {
        path: "/series/:id/season/:season_id/episode/:episode_id/voiceover/:voiceover_id",
        component: EpisodeVideoPlayer,
    },
    {
        path: "/films",
        component: FilmsPage,
    },
    {
        path: "/series",
        component: AllSeriesPage,
    },
    {
        path: "/:catchAll(.*)",
        component: NotFound,
    },
];

const router = createRouter({
    routes,
    history: createWebHistory(process.env.BASE_URL),
});

export default router;
