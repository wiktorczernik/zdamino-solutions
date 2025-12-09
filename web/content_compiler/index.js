import dotenv from 'dotenv';
import { readdir, readFile, mkdir } from 'fs/promises';
import { join, resolve } from 'path';

async function findInfoFiles(dir) 
{
    let result = [];

    const entries = await readdir(dir, { withFileTypes: true });

    for (const entry of entries)
    {
        const fullPath = join(dir, entry.name);

        if (entry.isDirectory())
        {
            const sub = await findInfoFiles(fullPath);
            result.push(...sub);
        }
        else if (entry.isFile() && entry.name == "info.json")
        {
            result.push(resolve(fullPath));
        }
    }

    return result;
}


//dotenv.config();

const solutionsPath = process.env.SOLUTIONS_PATH || "../../rozwiazania";
const infoFiles = await findInfoFiles(solutionsPath);
const infos = []
for(const infoFile of infoFiles)
{
    console.log(infoFile)
    const data = await readFile(infoFile, "utf-8");
    infos.push(JSON.parse(data));
}
console.log(infos)